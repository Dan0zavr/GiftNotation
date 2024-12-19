using GiftNotation.Services;
using GiftNotation.Services.Mediators;
using GiftNotation.ViewModels;
using GiftNotation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.Commands.EventCommands
{
    public class OpenAddEventCommand : ICommand
    {
        
        private readonly EventService _eventService;
        private readonly ContactService _contactService;
        private readonly EventViewModel _viewModel;
        private readonly GiftService _giftService;
        private readonly IDateMediator _dateMediator;

        public OpenAddEventCommand(EventService eventService, EventViewModel eventViewModel, ContactService contactService, GiftService giftService, IDateMediator dateMediator)
        {
            _eventService = eventService;
            _contactService = contactService;
            _viewModel = eventViewModel;
            _giftService = giftService;
            _dateMediator = dateMediator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var addEventViewModel = new AddEventViewModel(_eventService, _viewModel, _contactService, _giftService, _dateMediator);
            var addEventWindow = new AddEvent
            {
                DataContext = addEventViewModel
            };

            addEventWindow.ShowDialog();
        }
    }
}
