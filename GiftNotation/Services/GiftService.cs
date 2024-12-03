using GiftNotation.Data;
using GiftNotation.Models;
using GiftNotation.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ContactName = g.GiftContacts.FirstOrDefault().Contact.ContactName ?? string.Empty,
                    EventName = g.GiftEvents.FirstOrDefault().Event.EventName ?? string.Empty   
                })
                .ToListAsync();
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

            // Если статус не найден, создаем новый
            var newStatus = new Status { StatusName = statusName };
            _context.Statuses.Add(newStatus);
            await _context.SaveChangesAsync();

            return newStatus.StatusId;
        }

        public async Task<int> AddGiftAsync(DisplayGiftModel giftModel)
        {
            try
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

                return gift.GiftId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в AddGiftAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AddGiftContactAsync(int giftId, int contactId)
        {
            var giftContact = new GiftContact
            {
                GiftId = giftId,
                ContactId = contactId
            };
            _context.GiftContacts.Add(giftContact);
            await _context.SaveChangesAsync();
        }

        public async Task AddGiftEventAsync(int giftId, int eventId)
        {
            var giftEvent = new GiftEvent
            {
                GiftId = giftId,
                EventId = eventId
            };
            _context.GiftEvents.Add(giftEvent);
            await _context.SaveChangesAsync();
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

        public async Task DeleteGiftContact(int giftId)
        {
            var gift = await _context.GiftContacts.FindAsync(giftId);
            if (gift != null)
            {
                _context.GiftContacts.Remove(gift);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<int?> GetStatusIdByNameAsync(string? statusName)
        {
            return await _context.Statuses
                .Where(s => s.StatusName == statusName)
                .Select(s => s.StatusId)
                .FirstOrDefaultAsync();
        }


    }
}