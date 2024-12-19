﻿using GiftNotation.Data;
using GiftNotation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftNotation.ViewModels;

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

        public async Task<IEnumerable<Contact>> GetAllContactsOnEvent(int eventId)
        {
            // Используем запрос, чтобы получить все контакты, связанные с данным событием
            var contacts = await _context.EventContacts
                .Where(ec => ec.EventId == eventId)
                .Include(ec => ec.Contact) // Включаем информацию о контакте
                .Select(ec => ec.Contact) // Получаем только контакты
                .ToListAsync();

            return contacts;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsNotOnEvent(int eventId)
        {
            // Получаем все контакты, которые не привязаны к событию
            var contacts = await _context.Contacts
                .Where(c => !_context.EventContacts
                    .Any(ec => ec.ContactId == c.ContactId && ec.EventId == eventId))
                .ToListAsync();

            return contacts;
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
                    Bday = c.Bday,
                    RelpTypeName = c.RelpType.RelpTypeName ?? string.Empty,
                    //GiftName = c.GiftContacts
                    //    .Select(gc => gc.Gift.GiftName ?? string.Empty)
                    //    .FirstOrDefault() ?? string.Empty,
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
                MyGifts = new ObservableCollection<Gifts?> (
                    c.GiftContacts.Select(gc=>gc.Gift)
                    )
                //GiftId = c.GiftContacts.Select(gc => gc.GiftId).FirstOrDefault(), // Берём ID первого подарка
                //GiftName = c.GiftContacts
                //    .Select(gc => gc.Gift.GiftName ?? string.Empty)
                //    .FirstOrDefault() ?? string.Empty // Берём имя первого подарка
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

        public async Task AddContactAsync(DisplayContactModel contactModel)
        {
            // Убеждаемся, что статус существует, или добавляем его
            var relpTypeId = await EnsureRelpTypeAsync(contactModel.RelpTypeName);

            var contact = new Contact
            {
                ContactName = contactModel.ContactName ?? string.Empty,
                Bday = contactModel.Bday,
                RelpTypeId = relpTypeId // Может быть null
            };

            // Добавляем новый контакт
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            // Теперь contact.ContactId содержит сгенерированное значение
            foreach (var gift in contactModel.MyGifts)
            {
                var eventContact = new GiftContact
                {
                    GiftId = gift.GiftId,
                    ContactId = contact.ContactId // Используем сгенерированный ContactId
                };

                // Добавляем связь в контекст
                _context.GiftContacts.Add(eventContact);
            }

            await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();


                var birthDay = _context.Events.Where(e => e.EventDate == contact.Bday).FirstOrDefault();
                if (birthDay != null)
                {
                    _context.Events.Remove(birthDay);
                }
                _context.Contacts.Remove(contact);

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateContactAsync(DisplayContactModel contactModel, ChangeContactViewModel viewModel)
        {
            var existingContact = await _context.Contacts
                .FirstOrDefaultAsync(e => e.ContactId == contactModel.ContactId);

            existingContact.ContactName = contactModel.ContactName;
            existingContact.Bday = contactModel.Bday;
            existingContact.RelpTypeId = await EnsureRelpTypeAsync(contactModel.RelpTypeName);

            // 3. Удаляем старые связи между подарками и контактом
            var giftContactsToRemove = _context.GiftContacts
                .Where(ec => ec.ContactId == contactModel.ContactId);

            _context.GiftContacts.RemoveRange(giftContactsToRemove);

            // 4. Создаем новые связи между подарками и контактом
            foreach (var gift in viewModel.GiftsForContact)
            {
                var eventContact = new GiftContact
                {
                    GiftId = gift.GiftId,
                    ContactId = contactModel.ContactId
                };

                // Добавляем связь в контекст
                _context.GiftContacts.Add(eventContact);
            }

            // 5. Сохраняем изменения
            await _context.SaveChangesAsync();

        }
    }
}

