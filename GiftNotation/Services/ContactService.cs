using GiftNotation.Data;
using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{
    public class ContactService : IContactService
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

        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> UpdateContact(int id)
        {
            throw new NotImplementedException();
        }
    }
}
