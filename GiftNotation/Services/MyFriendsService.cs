using GiftNotation.Data;
using GiftNotation.GlobalFunctions;
using GiftNotation.Models;
using GiftNotation.Services.UniversalService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{

    public class MyFriendsService : NotifyObject, IMyFriendsService
    {
        private string? name;
        private DateTime birthday;
        private string? gift;
        private string? ship;

        private readonly GiftNotationDbContext _context;

        public MyFriendsService(GiftNotationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyFriends>> GetAllMyFriends()
        {
            return await _context.Set<MyFriends>().ToListAsync();
        }

        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        if (name != value)
        //        {
        //            name = value;
        //            OnPropertyChanged(nameof(Name));
        //        }
        //    }
        //}

        //public DateTime Birthday
        //{
        //    get { return birthday; }
        //    set
        //    {
        //        if (birthday != value)
        //        {
        //            birthday = value;
        //            OnPropertyChanged(nameof(Birthday));
        //        }
        //    }
        //}

        //public string Gift
        //{
        //    get { return gift; }
        //    set
        //    {
        //        if (gift != value)
        //        {
        //            gift = value;
        //            OnPropertyChanged(nameof(Gift));
        //        }
        //    }
        //}

        //public string Ship
        //{
        //    get => ship;
        //    set
        //    {
        //        if (ship != value)
        //        {
        //            ship = value;
        //            OnPropertyChanged(nameof(Ship));
        //        }
        //    }
        //}



    }
}
