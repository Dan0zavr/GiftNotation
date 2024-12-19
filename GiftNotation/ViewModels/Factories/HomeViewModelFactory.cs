using GiftNotation.Services;
using GiftNotation.Services.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels.Factories
{
    public class HomeViewModelFactory : IGiftNotationViewModelFactory<CalendarViewModel>
    {
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly EventViewModel _eventViewModel;
        private readonly GiftService _giftService;
        private readonly IDateMediator _dateMediator;

        public HomeViewModelFactory(EventService eventService, ContactService contactService, EventViewModel eventViewModel, GiftService giftService, IDateMediator mediator)
        {
            _eventService = eventService;
            _contactService = contactService;
            _eventViewModel = eventViewModel;
            _giftService = giftService;
            _dateMediator = mediator;
        }

        public CalendarViewModel CreateViewModel() { 

            return new CalendarViewModel(_eventService, _contactService, _eventViewModel, _giftService, _dateMediator);
        }
    }
}
