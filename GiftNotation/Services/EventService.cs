using GiftNotation.Data;
using GiftNotation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{
    public class EventService
    {
        private readonly GiftNotationDbContext _context;
        public event Action StateChanged;

        public EventService(GiftNotationDbContext context)
        {
            _context = context;
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

        public async Task AddEventAsync(DisplayEventModel eventModel)
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
        public async Task UpdateEventAsync(DisplayEventModel _event)
        {
            var eventChange = await _context.Events.FindAsync(_event.EventId);
            var eventContactChange = await _context.EventContacts.FindAsync(_event.EventId, _event.ContactsOnEvent);

            eventChange.EventName = _event.EventName;
            eventChange.EventDate = _event.EventDate;
            eventChange.EventTypeId = await EnsureTypeAsync(_event.EventTypeName);

            //if (eventContactChange != null)
            //{
            //    _context.GiftEvents.Remove(eventContactChange);
            //    var newGiftEvent = new GiftEvent()
            //    {
            //        ContactId = _event.ContactsOnEvent.EventId ?? 0,
            //        EventId = _event.EventId
            //    };
            //    _context.GiftEvents.Add(newGiftEvent);
            //}
            //else
            //{
            //    if (_gift.SelectedEventId != null)
            //    {
            //        var newGiftEvent = new GiftEvent()
            //        {
            //            EventId = _gift.SelectedEventId ?? 0,
            //            GiftId = _gift.GiftId
            //        };

            //        _context.GiftEvents.Add(newGiftEvent);
            //    }
            //}
            await _context.SaveChangesAsync();
        }

    }
}

