using GiftNotation.Services;
using GiftNotation.ViewModels;
using System.Windows.Input;

namespace GiftNotation.Commands.ContactCommands
{
    public class DeleteContactCommand : ICommand
    {
        private readonly ContactViewModel _viewModel;
        private readonly ContactService _contactService;
        private readonly EventService _eventService;

        public DeleteContactCommand(ContactViewModel viewModel, ContactService contactService, EventService eventService)
        {
            _viewModel = viewModel;
            _contactService = contactService;
            _eventService = eventService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedContact != null;
        }

        public async void Execute(object? parameter)
        {
            if (_viewModel.SelectedContact == null) return;



            var birthdayEvent = await _eventService.GetEventByContactAndTypeAsync(_viewModel.SelectedContact.ContactId);
            if (birthdayEvent != null)
            {
                await _eventService.DeleteEventAsync(birthdayEvent.EventId);
            }
            await _contactService.DeleteContactAsync(_viewModel.SelectedContact.ContactId);


            // Удаление из коллекции и сброс выделения
            _viewModel.Contacts.Remove(_viewModel.SelectedContact);
            _viewModel.SelectedContact = null;


        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
