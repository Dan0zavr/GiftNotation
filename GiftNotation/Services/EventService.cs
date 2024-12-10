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

    }
}

