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

        //public async Task<IEnumerable<Contact>> GetAllContacts()
        //{
        //    //return await _context.Contacts
        //    //    .Include(g => g.RelpType)
        //    //    .Include(g => g.EventContacts)
        //    //        .ThenInclude(gc => gc.Contact)
        //    //    .Include(g => g.GiftContacts)
        //    //        .ThenInclude(ge => ge.Gift)
        //    //    .Select(g => new DisplayContactModel
        //    //    {
        //    //        ContactId = g.ContactId,
        //    //        ContactName = g.ContactName ?? string.Empty,
        //    //        RelpType = g.RelpType.RelpTypeName ?? string.Empty,
        //    //        ContactGifts = g.GiftContacts.Gift.GiftName 
        //    //    })
        //    //    .ToListAsync();
        //}
    }
}
