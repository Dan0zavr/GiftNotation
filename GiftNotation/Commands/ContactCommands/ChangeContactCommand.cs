using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Commands.ContactCommands
{
    public class ChangeContactCommand : ICommand
    {
        private readonly ContactService _contactService;
        private readonly ChangeContactViewModel _viewModel;
        private readonly ContactViewModel _contactViewModel;
        private readonly EventService _eventService;

        public ChangeContactCommand(ContactService contactService, ContactViewModel contactViewModel, ChangeContactViewModel viewModel, EventService eventService)
        {
            _contactService = contactService;
            _viewModel = viewModel;
            _contactViewModel = contactViewModel;
            _eventService = eventService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            var changeContact = new DisplayContactModel
            {
                ContactId = _viewModel.ContactId,
                ContactName = _viewModel.ContactName,
                Bday = _viewModel.Bday,
                RelpTypeName = _viewModel.SelectedRelpType?.RelpTypeName
            };
            var birthdayEvent = await _eventService.GetEventByContactAndTypeAsync(changeContact.ContactId);
            await _eventService.DeleteEventAsync(birthdayEvent.EventId);
            await _contactService.UpdateContactAsync(changeContact, _viewModel);
            await _eventService.AddContactBday();


            _contactViewModel.LoadContacts();

            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
