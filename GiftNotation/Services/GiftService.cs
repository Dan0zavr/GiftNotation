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
    public class GiftService
    {
        private readonly GiftNotationDbContext _context;
        public event Action StateChanged;

        public GiftService(GiftNotationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GiftDisplayModel>> GetGiftsAsync()
        {
            return await _context.Gifts
                .Include(g => g.Status)
                .Include(g => g.GiftContacts)
                    .ThenInclude(gc => gc.Contact)
                .Include(g => g.GiftEvents)
                    .ThenInclude(ge => ge.Event)
                .Select(g => new GiftDisplayModel
                {
                    GiftId = g.GiftId,
                    GiftName = g.GiftName,
                    Description = g.Description,
                    Url = g.Url,
                    Price = g.Price,
                    GiftPic = g.GiftPic,
                    StatusName = g.Status.StatusName,
                    ContactName = g.GiftContacts.FirstOrDefault().Contact.ContactName,
                    EventName = g.GiftEvents.FirstOrDefault().Event.EventName


                })
                .ToListAsync(); 

        }
    }
}
