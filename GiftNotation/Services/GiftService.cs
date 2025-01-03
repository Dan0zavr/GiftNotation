﻿using GiftNotation.Data;
using GiftNotation.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Services
{
    public class GiftService
    {
        private readonly GiftNotationDbContext _context;
        public event Action StateChanged;

        public GiftService(GiftNotationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisplayGiftModel>> GetGiftAsync()
        {
            return await _context.Gifts
                .Include(g => g.Status)
                .Include(g => g.GiftContacts)
                    .ThenInclude(gc => gc.Contact)
                .Include(g => g.GiftEvents)
                    .ThenInclude(ge => ge.Event)
                .Select(g => new DisplayGiftModel
                {
                    GiftId = g.GiftId,
                    GiftName = g.GiftName ?? string.Empty,
                    Description = g.Description ?? string.Empty,
                    Price = g.Price,
                    GiftPic = g.GiftPic ?? string.Empty,
                    Url = g.Url ?? string.Empty,
                    StatusName = g.Status.StatusName ?? string.Empty,

                    ContactId = g.GiftContacts.Select(gc => gc.ContactId).First(),
                    ContactName = g.GiftContacts.Select(gc => gc.Contact.ContactName ?? string.Empty).FirstOrDefault(),

                    EventId = g.GiftEvents.Select(ge => ge.EventId).First(),
                    EventName = g.GiftEvents.Select(ge => ge.Event.EventName ?? string.Empty).FirstOrDefault()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Gifts>> GetAllGiftsForContact(int contactId)
        {
            var gifts = await _context.GiftContacts
                .Where(ec => ec.ContactId == contactId)
                .Include(ec => ec.Gift) // Включаем информацию о контакте
                .Select(ec => ec.Gift) // Получаем только контакты
                .ToListAsync();

            return gifts;
        }

        public async Task<IEnumerable<Gifts>> GetAllGiftNotForContact(int contactId)
        {
            // Получаем все контакты, которые не привязаны к событию
            var gifts = await _context.Gifts
                .Where(c => !_context.GiftContacts
                    .Any(ec => ec.GiftId == c.GiftId && ec.ContactId == contactId))
                .ToListAsync();

            return gifts;
        }

        public async Task AddGiftAsync(DisplayGiftModel giftModel)
        {

            // Убеждаемся, что статус существует, или добавляем его
            var statusId = await EnsureStatusAsync(giftModel.StatusName);

            var gift = new Gifts
            {
                GiftName = giftModel.GiftName ?? string.Empty,
                Description = giftModel.Description ?? string.Empty,
                Price = giftModel.Price,
                GiftPic = giftModel.GiftPic ?? string.Empty,
                Url = giftModel.Url ?? string.Empty,
                StatusId = statusId // Может быть null
            };

            _context.Gifts.Add(gift);
            await _context.SaveChangesAsync();


            var addedGift = await _context.Gifts
        .OrderByDescending(e => e.GiftId) // Упорядочиваем по убыванию идентификатора
        .FirstOrDefaultAsync();

            if (giftModel.SelectedEventId != null)
            {
                var newGiftEvent = new GiftEvent()
                {
                    EventId = giftModel.SelectedEventId ?? 0,
                    GiftId = addedGift.GiftId
                };
                _context.GiftEvents.Add(newGiftEvent);
            }
            if (giftModel.SelectedContactId != null)
            {
                var newGiftContact = new GiftContact()
                {
                    ContactId = giftModel.SelectedContactId ?? 0,
                    GiftId = addedGift.GiftId
                };
                _context.GiftContacts.Add(newGiftContact);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGiftAsync(int giftId)
        {
            var gift = await _context.Gifts
                .Include(g => g.GiftContacts)
                .Include(g => g.GiftEvents)
                .FirstOrDefaultAsync(g => g.GiftId == giftId);

            if (gift != null)
            {
                // Удаляем связанные контакты и события
                _context.GiftContacts.RemoveRange(gift.GiftContacts);
                _context.GiftEvents.RemoveRange(gift.GiftEvents);

                // Удаляем сам подарок
                _context.Gifts.Remove(gift);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DisplayGiftModel>> GetDisplayGiftModelByID(int giftId)
        {
            var gift = await _context.Gifts
        .Include(g => g.Status)
        .Include(g => g.GiftContacts)
            .ThenInclude(gc => gc.Contact)
        .Include(g => g.GiftEvents)
            .ThenInclude(ge => ge.Event)
        .Where(g => g.GiftId == giftId)
        .FirstOrDefaultAsync();

            return await _context.Gifts
                 .Include(g => g.Status)
                 .Include(g => g.GiftContacts)
                     .ThenInclude(gc => gc.Contact)
                 .Where(g => g.GiftId == giftId)
                 .Include(g => g.GiftEvents)
                     .ThenInclude(ge => ge.Event)
                 .Where(g => g.GiftId == giftId)
                 .Select(g => new DisplayGiftModel
                 {
                     GiftId = g.GiftId,
                     GiftName = g.GiftName ?? string.Empty,
                     Description = g.Description ?? string.Empty,
                     Price = g.Price,
                     GiftPic = g.GiftPic ?? string.Empty,
                     Url = g.Url ?? string.Empty,
                     StatusName = g.Status.StatusName ?? string.Empty,
                     ContactId = g.GiftContacts
                     .Where(gc => gc.GiftId == gift.GiftId)
                     .Select(gc => gc.ContactId)
                     .First(),
                     ContactName = g.GiftContacts
                     .Where(gc => gc.GiftId == gift.GiftId)
                     .Select(gc => gc.Contact.ContactName)
                     .FirstOrDefault() ?? string.Empty,
                     EventId = g.GiftEvents
                     .Where(gc => gc.GiftId == gift.GiftId)
                     .Select(gc => gc.EventId)
                     .First(),
                     EventName = g.GiftEvents
                     .Where(ge => ge.GiftId == gift.GiftId)
                     .Select(ge => ge.Event.EventName)
                     .FirstOrDefault() ?? string.Empty
                 })
                 .ToListAsync();
        }



        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task UpdateGiftAsync(DisplayGiftModel _gift)
        {
            var giftChange = await _context.Gifts.FindAsync(_gift.GiftId);
            if (giftChange == null)
            {
                throw new InvalidOperationException("Gift not found.");
            }

            giftChange.GiftName = _gift.GiftName ?? string.Empty;
            giftChange.Description = _gift.Description ?? string.Empty;
            giftChange.Url = _gift.Url ?? string.Empty;
            giftChange.Price = _gift.Price;
            giftChange.GiftPic = _gift.GiftPic ?? string.Empty;
            giftChange.StatusId = await EnsureStatusAsync(_gift.StatusName);

            // Обновляем GiftEvent
            if (_gift.EventId != null && _gift.EventId > 0)
            {
                var giftEventChange = await _context.GiftEvents
                    .FirstOrDefaultAsync(ge => ge.GiftId == _gift.GiftId);

                if (giftEventChange != null)
                {
                    if (giftEventChange.EventId != _gift.EventId.Value)
                    {
                        // Удаляем текущую связь, если ID события изменился
                        _context.GiftEvents.Remove(giftEventChange);

                        // Добавляем новое событие
                        var newGiftEvent = new GiftEvent
                        {
                            EventId = _gift.EventId.Value,
                            GiftId = _gift.GiftId
                        };
                        _context.GiftEvents.Add(newGiftEvent);
                    }
                }
                else
                {
                    // Если связь отсутствует, создаем её
                    var newGiftEvent = new GiftEvent
                    {
                        EventId = _gift.EventId.Value,
                        GiftId = _gift.GiftId
                    };
                    _context.GiftEvents.Add(newGiftEvent);
                }
            }

            // Обновляем GiftContact
            if (_gift.ContactId != null && _gift.ContactId > 0)
            {
                var giftContactChange = await _context.GiftContacts
                    .FirstOrDefaultAsync(gc => gc.GiftId == _gift.GiftId);

                if (giftContactChange != null)
                {
                    if (giftContactChange.ContactId != _gift.ContactId.Value)
                    {
                        // Удаляем текущую связь, если ID контакта изменился
                        _context.GiftContacts.Remove(giftContactChange);

                        // Добавляем новый контакт
                        var newGiftContact = new GiftContact
                        {
                            ContactId = _gift.ContactId.Value,
                            GiftId = _gift.GiftId
                        };
                        _context.GiftContacts.Add(newGiftContact);
                    }
                }
                else
                {
                    // Если связь отсутствует, создаем её
                    var newGiftContact = new GiftContact
                    {
                        ContactId = _gift.ContactId.Value,
                        GiftId = _gift.GiftId
                    };
                    _context.GiftContacts.Add(newGiftContact);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int?> EnsureStatusAsync(string? statusName)
        {
            if (string.IsNullOrEmpty(statusName))
                return null; // Возвращаем null, если статус не указан

            // Проверяем, существует ли статус
            var existingStatusId = await _context.Statuses
                .Where(s => s.StatusName == statusName)
                .Select(s => s.StatusId)
                .FirstOrDefaultAsync();

            if (existingStatusId != 0)
                return existingStatusId;

            return null;
        }

        public async Task<IEnumerable<Gifts>> GetAllGifts()
        {
            return await _context.Gifts.ToListAsync();
        }

        public async Task<IEnumerable<Gifts>> GetGiftsNotForContact()
        {
            // Получаем все подарки, которые не привязаны к контактам
            var giftsNotForContact = await _context.Gifts
                .Where(g => !_context.GiftContacts
                    .Any(gc => gc.GiftId == g.GiftId))
                .ToListAsync();

            return giftsNotForContact;
        }

    }
}