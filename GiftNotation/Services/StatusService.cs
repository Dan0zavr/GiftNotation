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
    public class StatusService
    {
        private readonly GiftNotationDbContext _context;
        public event Action StateChanged;

        public StatusService(GiftNotationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}
