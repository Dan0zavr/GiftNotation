using GiftNotation.Data;
using GiftNotation.Models;
using GiftNotation.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GiftNotation.Services
{
    public class EventService
    {
        private readonly GiftNotationDbContext _context;
        private readonly ContactService _contactService;
        public event Action StateChanged;

        public EventService(GiftNotationDbContext context, ContactService contactService)
        {
            _context = context;
            _contactService = contactService;
        }

        public async Task<List<Event>> GetEventsByDate(DateTime date)
        {
            // Предположим, что у вас есть модель Event и ее данные хранятся в базе данных
            return await _context.Events
                .Where(e => e.EventDate == date.Date)
                .ToListAsync();  // Вернем список событий для этой даты
        }

        public async Task<DisplayEventModel?> GetEventByContactAndTypeAsync(int contactId)
        {
            return await _context.Events
                .Include(e => e.EventType) // Подгружаем тип события
                .Include(e => e.EventContacts) // Подгружаем связи событие-контакты
                    .ThenInclude(ec => ec.Contact) // Подгружаем сами контакты
                .Where(e => e.EventType.EventTypeId == 1 &&
                            e.EventContacts.Any(ec => ec.ContactId == contactId)) // Фильтр по типу события и контакту
                .Select(e => new DisplayEventModel
                {
                    EventId = e.EventId,
                    EventName = e.EventName,
                    EventDate = e.EventDate,
                    EventTypeName = e.EventType.EventTypeName ?? string.Empty,
                    ContactsOnEvent = new ObservableCollection<Contact?>(
                        e.EventContacts.Select(ec => ec.Contact)
                    )
                })
                .FirstOrDefaultAsync(); // Возвращаем первый найденный результат
        }

        public async Task<IEnumerable<DisplayEventModel>> GetEventsAsync()
        {
            return await _context.Events
                .Include(e => e.EventType) // Подгружаем тип события
                .Include(e => e.EventContacts) // Подгружаем связи событие-контакты
                    .ThenInclude(ec => ec.Contact) // Подгружаем сами контакты
                .Select(e => new DisplayEventModel
                {
                    EventId = e.EventId,
                    EventName = e.EventName,
                    EventDate = e.EventDate,
                    EventTypeName = e.EventType.EventTypeName ?? string.Empty,
                    ContactsOnEvent = new ObservableCollection<Contact?>(
                        e.EventContacts.Select(ec => ec.Contact)
                    )
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<DateTime>> GetAllEventDates()
        {
            return await _context.Events.Select(d => d.EventDate).ToListAsync();
        }

        public async Task AddEventAsync(DisplayEventModel eventModel, AddEventViewModel addEventViewModel)
        {
            var typeId = await EnsureTypeAsync(eventModel.EventTypeName);

            var event_ = new Event
            {
                EventName = eventModel.EventName,
                EventDate = eventModel.EventDate,
                EventTypeId = typeId
            };

            _context.Events.Add(event_);
            await _context.SaveChangesAsync();

            var addedEvent = await _context.Events
            .OrderByDescending(e => e.EventId) // Упорядочиваем по убыванию ID
            .FirstOrDefaultAsync();

            if (addedEvent != null)
            {
                // 5. Создаем связи между событием и контактами
                foreach (var contact in addEventViewModel.ContactsOnEvent)
                {
                    var eventContact = new EventContact
                    {
                        EventId = addedEvent.EventId,
                        ContactId = contact.ContactId
                    };

                    // Добавляем связь в контекст
                    _context.EventContacts.Add(eventContact);
                }

                // 6. Сохраняем изменения
                await _context.SaveChangesAsync();
            }

        }

        public async Task<int?> EnsureTypeAsync(string? typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return null; // Возвращаем null, если статус не указан

            // Проверяем, существует ли статус
            var existingStatusId = await _context.EventTypes
                .Where(s => s.EventTypeName == typeName)
                .Select(s => s.EventTypeId)
                .FirstOrDefaultAsync();

            if (existingStatusId != 0)
                return existingStatusId;

            return null;
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var event_ = await _context.Events
                .Include(g => g.EventContacts)
                .Include(g => g.GiftEvents)
                .FirstOrDefaultAsync(g => g.EventId == eventId);

            if (event_ != null)
            {
                _context.EventContacts.RemoveRange(event_.EventContacts);
                _context.GiftEvents.RemoveRange(event_.GiftEvents);

                _context.Events.Remove(event_);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DisplayEventModel>> GetDisplayEventModelByID(int id)
        {
            var event_ = await _context.Events
                .Include(e => e.EventType) // Подгружаем тип события
                .Include(e => e.EventContacts) // Подгружаем связи событие-контакты
                    .ThenInclude(ec => ec.Contact) // Подгружаем сами контакты
                .Where(g => g.EventId == id)
                .FirstOrDefaultAsync();

            return await _context.Events
                .Include(e => e.EventType) // Подгружаем тип события
                .Include(e => e.EventContacts) // Подгружаем связи событие-контакты
                    .ThenInclude(ec => ec.Contact) // Подгружаем сами контакты
                .Where(g => g.EventId == id)
                .Select(e => new DisplayEventModel
                {
                    EventId = e.EventId,
                    EventDate = e.EventDate,
                    EventName = e.EventName,
                    EventTypeName = e.EventType.EventTypeName,

                })
                .ToListAsync();

        }
        public async Task UpdateEventAsync(DisplayEventModel eventModel, ChangeEventViewModel addEventViewModel)
        {
            // 1. Получаем событие по ID (предполагается, что eventModel содержит EventId)
            var existingEvent = await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == eventModel.EventId);

            if (existingEvent == null)
            {
                // Если событие не найдено, можно выбросить исключение или обработать ошибку
                throw new Exception("Событие не найдено");
            }

            // 2. Обновляем информацию о событии
            existingEvent.EventName = eventModel.EventName;
            existingEvent.EventDate = eventModel.EventDate;
            existingEvent.EventTypeId = await EnsureTypeAsync(eventModel.EventTypeName);

            // 3. Удаляем старые связи между событием и контактами
            var eventContactsToRemove = _context.EventContacts
                .Where(ec => ec.EventId == eventModel.EventId);

            _context.EventContacts.RemoveRange(eventContactsToRemove);

            // 4. Создаем новые связи между событием и контактами
            foreach (var contact in addEventViewModel.ContactsOnEvent)
            {
                var eventContact = new EventContact
                {
                    EventId = eventModel.EventId,
                    ContactId = contact.ContactId
                };

                // Добавляем связь в контекст
                _context.EventContacts.Add(eventContact);
            }

            // 5. Сохраняем изменения
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventType>> GetEventTypesAsync()
        {
            return await _context.EventTypes.ToListAsync();
        }

        public async Task<IEnumerable<DisplayEventModel>> FilterEvents(string month, string eventType, string relpType)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.EventType) // Подгружаем тип события
            .Include(e => e.EventContacts) // Подгружаем связи событие-контакты
                .ThenInclude(ec => ec.Contact);

            if (month != "Без фильтра" && month != null)
            {

                int monthNumber = GetMonthNumber(month);
                query = query.Where(e => e.EventDate.Month == monthNumber);
            }

            if (eventType != "Без фильтра" && month != null)
            {
                query = query.Where(e => e.EventType.EventTypeName == eventType);
            }

            if (relpType != "Без фильтра" && month != null)
            {
                query = query.Where(e => e.EventContacts.Any(ec => ec.Contact.RelpType.RelpTypeName == relpType));
            }

            var result = await query.Select(e => new DisplayEventModel
            {
                EventId = e.EventId,
                EventName = e.EventName,
                EventDate = e.EventDate,
                EventTypeName = e.EventType.EventTypeName,
                ContactsOnEvent = new ObservableCollection<Contact?>(
                        e.EventContacts.Select(ec => ec.Contact))
            }).ToListAsync();

            return result;
        }

        private int GetMonthNumber(string month)
        {
            return month switch
            {
                "Январь" => 1,
                "Февраль" => 2,
                "Март" => 3,
                "Апрель" => 4,
                "Май" => 5,
                "Июнь" => 6,
                "Июль" => 7,
                "Август" => 8,
                "Сентябрь" => 9,
                "Октябрь" => 10,
                "Ноябрь" => 11,
                "Декабрь" => 12
            };

        }

        public async Task AddContactBday()
        {
            var currentYear = DateTime.Now.Year;
            var contacts = await _contactService.GetAllContacts();

            var eventsToAdd = new List<Event>();
            var eventContactsToAdd = new List<EventContact>();

            foreach (var contact in contacts)
            {
                var currentBdayMonth = contact.Bday.Month;
                var currentBdayDay = contact.Bday.Day;
                var todayBday = new DateTime(currentYear, currentBdayMonth, currentBdayDay);

                // Если день рождения в этом году уже прошел, то сдвигаем на следующий год
                if (todayBday < DateTime.Now)
                {
                    todayBday = todayBday.AddYears(1);
                }

                // Проверяем, существует ли событие на эту дату для этого контакта
                var existingEvent = await _context.Events
                    .Where(e => e.EventDate == todayBday && e.EventName == "День рождения: " + contact.ContactName)
                    .FirstOrDefaultAsync();

                if (existingEvent == null)
                {
                    // Создаем новое событие для данного контакта, если его нет
                    var bdayEvent = new Event
                    {
                        EventName = "День рождения: " + contact.ContactName,
                        EventDate = todayBday,
                        EventTypeId = 1
                    };
                    eventsToAdd.Add(bdayEvent);

                    // Добавляем связь между контактом и событием
                    eventContactsToAdd.Add(new EventContact
                    {
                        Event = bdayEvent, // связь с только что добавленным событием
                        ContactId = contact.ContactId,
                    });
                }
                else
                {
                    // Если событие существует, добавляем только связь
                    var existingEventContact = await _context.EventContacts
                        .Where(ec => ec.EventId == existingEvent.EventId && ec.ContactId == contact.ContactId)
                        .FirstOrDefaultAsync();

                    if (existingEventContact == null)
                    {
                        // Если такой связи нет, добавляем её
                        eventContactsToAdd.Add(new EventContact
                        {
                            EventId = existingEvent.EventId,
                            ContactId = contact.ContactId,
                        });
                    }
                }
            }

            // Добавляем все новые события за один раз
            if (eventsToAdd.Any())
            {
                _context.Events.AddRange(eventsToAdd);
                await _context.SaveChangesAsync();
            }

            // После сохранения событий, добавляем связи между событиями и контактами
            if (eventContactsToAdd.Any())
            {
                _context.EventContacts.AddRange(eventContactsToAdd);
                await _context.SaveChangesAsync();
            }
        }

    }
}

