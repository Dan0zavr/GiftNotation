using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.Services
{
    enum MyInputType
    {
        Name,
        Birthday,
        Gift,
        Ship
    }

    public interface IMyFriendsService
    {
        //string Name { get; set; }
        //DateTime Birthday { get; set; }
        //string Ship { get; set; }
        //string Gift { get; set; }

        Task<IEnumerable<MyFriends>> GetAllMyFriends();


    }
}
