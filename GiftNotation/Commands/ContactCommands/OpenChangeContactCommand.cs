using GiftNotation.Services;
using GiftNotation.ViewModels;
using GiftNotation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.Commands.ContactCommands
{
    public class OpenChangeContactCommand : ICommand
    {
        private readonly ContactViewModel _viewModel;
        private readonly ContactService _contactService;
        private readonly GiftService _giftService;
        private readonly EventService _eventService;

        public OpenChangeContactCommand(ContactViewModel viewModel, ContactService contactService, GiftService giftService, EventService eventService)
        {
            _viewModel = viewModel;
            _contactService = contactService;
            _giftService = giftService;
            _eventService = eventService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedContact != null;
        }

        public void Execute(object? parameter)
        {
            var changeContactViewModel = new ChangeContactViewModel(_contactService, _giftService, _viewModel, _eventService);
            var changeContactWindow = new ChangingPeople
            {
                DataContext = changeContactViewModel
            };

            changeContactWindow.ShowDialog();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

