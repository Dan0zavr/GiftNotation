using GiftNotation.Commands;
using GiftNotation.Models;
using GiftNotation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels
{
    public class MyFriendsViewModel : ViewModelBase
    {

        private readonly IMyFriendsService _friendsService;
        public ObservableCollection<MyFriends> Friends { get; }

        public MyFriendsViewModel(IMyFriendsService friendsService)
        {
            _friendsService = friendsService;
            Friends = new ObservableCollection<MyFriends>();

            // Загрузка данных при инициализации
            LoadMyFriendsAsync();
        }

        private async Task LoadMyFriendsAsync()
        {
            var allFriends = await _friendsService.GetAllMyFriends();
            Friends.Clear();
            foreach (var friend in allFriends)
            {
                Friends.Add(friend);
            }
        }

    }
}
