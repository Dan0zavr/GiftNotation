using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels.Factories
{
    public class MyFriendsViewModelFactory : IGiftNotationViewModelFactory<MyFriendsViewModel>
    {
        private readonly IMyFriendsService _friendsService;

        public MyFriendsViewModelFactory(IMyFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        public MyFriendsViewModel CreateViewModel()
        {
            return new MyFriendsViewModel(_friendsService);
        }
    }
}
