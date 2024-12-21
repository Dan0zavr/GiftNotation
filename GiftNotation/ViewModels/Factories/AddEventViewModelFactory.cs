using GiftNotation.Services;
using GiftNotation.Services.Mediators;

namespace GiftNotation.ViewModels.Factories
{
    public class AddEventViewModelFactory
    {
        private readonly IDateMediator _dateMediator;
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly GiftService _giftService;
        private readonly EventViewModel _eventViewModel;

        public AddEventViewModelFactory(IDateMediator dateMediator, EventService eventService, ContactService contactService, GiftService giftService, EventViewModel eventViewModel)
        {
            _dateMediator = dateMediator;
            _eventService = eventService;
            _contactService = contactService;
            _giftService = giftService;
            _eventViewModel = eventViewModel;
        }

        public AddEventViewModel Create(DateTime? initialDate)
        {
            var viewModel = new AddEventViewModel(_eventService, _eventViewModel, _contactService, _giftService, _dateMediator);
            if (initialDate.HasValue)
            {
                viewModel.EventDate = initialDate.Value;
            }
            return viewModel;
        }
    }
}
