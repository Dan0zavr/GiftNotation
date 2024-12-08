using GiftNotation.Data;
using GiftNotation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{
    public class ContactService
    {
        private readonly GiftNotationDbContext _context;
        public event Action StateChanged;

        public ContactService(GiftNotationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<RelpType>> GetAllRelpTypes()
        {
            return await _context.RelpTypes.ToListAsync();
        }

        public async Task<IEnumerable<DisplayContactModel>> GetContactDisplayModelByIdAsync(int contactId)
        {
            // Убедимся, что контакт с заданным ID существует
            var contact = await _context.Contacts
                .Include(c => c.RelpType)
                .Include(c => c.GiftContacts)
                    .ThenInclude(gc => gc.Gift)
                .FirstOrDefaultAsync(c => c.ContactId == contactId);

            if (contact == null)
            {
                return Enumerable.Empty<DisplayContactModel>();
            }

            // Возвращаем данные
            return await _context.Contacts
                .Include(c => c.RelpType)
                .Include(c => c.GiftContacts)
                    .ThenInclude(gc => gc.Gift)
                .Where(c => c.ContactId == contactId)
                .Select(c => new DisplayContactModel
                {
                    ContactId = c.ContactId,
                    ContactName = c.ContactName ?? string.Empty,
                    RelpTypeName = c.RelpType.RelpTypeName ?? string.Empty,
                    GiftName = c.GiftContacts
                        .Select(gc => gc.Gift.GiftName ?? string.Empty)
                        .FirstOrDefault() ?? string.Empty,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DisplayContactModel>> GetAllContactsAsync()
        {
        return await _context.Contacts
            .Include(c => c.RelpType) // Загружаем тип отношений
            .Include(c => c.GiftContacts)
                .ThenInclude(gc => gc.Gift) // Загружаем связанные подарки
            .Select(c => new DisplayContactModel
            {
                ContactId = c.ContactId,
                ContactName = c.ContactName ?? string.Empty,
                Bday = c.Bday,
                RelpTypeName = c.RelpType.RelpTypeName ?? string.Empty,
                GiftId = c.GiftContacts.Select(gc => gc.GiftId).FirstOrDefault(), // Берём ID первого подарка
                GiftName = c.GiftContacts
                    .Select(gc => gc.Gift.GiftName ?? string.Empty)
                    .FirstOrDefault() ?? string.Empty // Берём имя первого подарка
            })
            .ToListAsync();
        }

        public async Task<int?> EnsureRelpTypeAsync(string? relpTypeName)
        {
            if (string.IsNullOrEmpty(relpTypeName))
                return null; // Возвращаем null, если статус не указан

            // Проверяем, существует ли статус
            var existingRelpTypeId = await _context.RelpTypes
                .Where(s => s.RelpTypeName == relpTypeName)
                .Select(s => s.RelpTypeId)
                .FirstOrDefaultAsync();

            if (existingRelpTypeId != 0)
                return existingRelpTypeId;

            return null;
        }

        public async Task AddGiftAsync(DisplayContactModel contactModel)
        {

            // Убеждаемся, что статус существует, или добавляем его
            var relpTypeId = await EnsureRelpTypeAsync(contactModel.RelpTypeName);

            var contact = new Contact
            {
                ContactName = contactModel.ContactName ?? string.Empty,
                Bday = contactModel.Bday ?? null,
                RelpTypeId = relpTypeId // Может быть null
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            if (contactModel.GiftId != null)
            {

                var addedContact = await _context.Contacts
                .OrderByDescending(e => e.ContactId) // Упорядочиваем по убыванию идентификатора
                .FirstAsync();

            
                var newGiftContact = new GiftContact()
                {
                    ContactId = addedContact.ContactId,
                    GiftId = contactModel.GiftId ?? 0
                };
                _context.GiftContacts.Add(newGiftContact);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await _context.Contacts
                .Include(g => g.GiftContacts)
                .Include(g => g.EventContacts)
                .FirstOrDefaultAsync(g => g.ContactId == contactId);

            if (contact != null)
            {
                // Удаляем связанные контакты и события
                _context.GiftContacts.RemoveRange(contact.GiftContacts);
                _context.EventContacts.RemoveRange(contact.EventContacts);

                // Удаляем сам подарок
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}

