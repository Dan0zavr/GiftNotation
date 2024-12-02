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
    }
}
