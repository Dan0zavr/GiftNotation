using GiftNotation.Services;
using GiftNotation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.Commands.ContactCommands
{
    public class AddContactCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly ContactService _contactService;
        private readonly ContactViewModel _contactViewModel;


        public AddContactCommand(ContactService contactService, ContactViewModel contactViewModel)
        {
            _contactService = contactService;
            _contactViewModel = contactViewModel;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            //_contactService.AddContact(_contactViewModel.NewContact);
        }
    }
}
