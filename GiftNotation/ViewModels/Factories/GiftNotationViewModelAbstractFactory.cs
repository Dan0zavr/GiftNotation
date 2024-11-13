using GiftNotation.Services;
using GiftNotation.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels.Factories
{
    public class GiftNotationViewModelAbstractFactory : IGiftNotationViewModelAbstractFactory
    {
        private IGiftNotationViewModelFactory<CalendarViewModel> _calendarViewModelFactory;
        private IGiftNotationViewModelFactory<MyFriendsViewModel> _myfriendsViewModelFactory;

        public GiftNotationViewModelAbstractFactory(IGiftNotationViewModelFactory<CalendarViewModel> calendarViewModelFactory, IGiftNotationViewModelFactory<MyFriendsViewModel> myfriendsViewModelFactory)
        {
            _calendarViewModelFactory = calendarViewModelFactory;
            _myfriendsViewModelFactory = myfriendsViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Calendar:
                    // Создание новой модели представления для Calendar
                    return _calendarViewModelFactory.CreateViewModel();

                case ViewType.MyFriends:
                    // Создание MyFriendsViewModel с использованием переданного сервиса
                    return _myfriendsViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("Takogo net");
            }
        }
    }
}
