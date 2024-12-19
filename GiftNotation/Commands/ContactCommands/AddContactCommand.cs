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
    public class AddContactCommand : ICommand
    {
        private readonly ContactService _contactService;
        private readonly ContactViewModel _contactViewModel;
        private readonly AddContactViewModel _addContactViewModel;
        private readonly EventService _eventService;

        public AddContactCommand(ContactService contactService, ContactViewModel contactViewModel, AddContactViewModel addContactViewModel, EventService eventService)
        {
            _contactService = contactService;
            _contactViewModel = contactViewModel;
            _addContactViewModel = addContactViewModel;
            _eventService = eventService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(_addContactViewModel.ContactName);
        }

        public async void Execute(object? parameter)
        {
            var newContact = new DisplayContactModel
            {
                ContactName = _addContactViewModel.ContactName ?? string.Empty,
                Bday = _addContactViewModel.Bday,
                RelpTypeName = _addContactViewModel.SelectedRelpType?.RelpTypeName ?? string.Empty,
                MyGifts = _addContactViewModel.GiftsForContact,
            };

            await _contactService.AddContactAsync(newContact);
            await _eventService.AddContactBday();

            // Обновляем список подарков после добавления
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
