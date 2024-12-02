using GiftNotation.Services;
using GiftNotation.State.Navigators;
using GiftNotation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GiftNotation.ViewModels.Factories
{
    public class GiftNotationViewModelAbstractFactory : IGiftNotationViewModelAbstractFactory
    {
        private readonly IGiftNotationViewModelFactory<CalendarViewModel> _calendarViewModelFactory;
        private readonly ContactViewModel _contactViewModel;
        private readonly GiftViewModel _giftViewModel;
        private readonly EventViewModel _eventViewModel;
        private readonly SettingsViewModel _settigsViewModel;
        private readonly ProfileViewModel _profileViewModel;
        private readonly GiftService _giftService;

        public GiftNotationViewModelAbstractFactory(IGiftNotationViewModelFactory<CalendarViewModel> calendarViewModelFactory,
            ContactViewModel contactViewModel, GiftViewModel giftViewModel, EventViewModel eventViewModel, SettingsViewModel settigsViewModel, ProfileViewModel profileViewModel,
            GiftService giftService)
        {
            _calendarViewModelFactory = calendarViewModelFactory;
            _contactViewModel = contactViewModel;
            _giftViewModel = giftViewModel;
            _eventViewModel = eventViewModel;
            _settigsViewModel = settigsViewModel;
            _profileViewModel = profileViewModel;
            _giftService = giftService;

        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Calendar:
                    // Создание новой модели представления для Calendar
                    return _calendarViewModelFactory.CreateViewModel();
                case ViewType.Contacts:
                    return new ContactViewModel();
                case ViewType.Events:
                    return new EventViewModel();
                case ViewType.Gifts:
                    return new GiftViewModel(_giftService);
                case ViewType.Settings:
                    return new SettingsViewModel();
                case ViewType.Profile:
                    return new ProfileViewModel();
                default:
                    throw new ArgumentException("Takogo net");
            }
        }
    }
}
