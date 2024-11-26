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

        public ContactService(GiftNotationDbContext context)
        {
            _context = context;
        }

        public async Task AddContact(Contact contact)
        {
            await _context.Set<Contact>().AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteContact(int id)
        {
            var deletedContact = await _context.Set<Contact>().FindAsync(id);

            if (deletedContact != null)
            {
                _context.Set<Contact>().Remove(deletedContact);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ContactDisplayModel>> GetDisplayContactsAsync()
        {
            return await _context.Contacts
                .Include(c => c.RelpType)
                .Include(c => c.GiftContacts)
                    .ThenInclude(gc => gc.Gift)
                .Select(c => new ContactDisplayModel
                {
                    ContactId = c.ContactId,
                    ContactName = c.ContactName,
                    Bday = c.Bday,
                    RelpTypeName = c.RelpType.RelpTypeName,
                    GiftName = c.GiftContacts.FirstOrDefault().Gift.GiftName

                })
                .ToListAsync();
        }

        public Task<Contact> UpdateContact(int id)
        {
            throw new NotImplementedException();
        }
    }
}
