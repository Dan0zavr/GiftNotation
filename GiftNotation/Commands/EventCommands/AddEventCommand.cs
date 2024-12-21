using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.Services.Mediators;
using GiftNotation.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Commands.EventCommands
{
    public class AddEventCommand : ICommand
    {
        private readonly EventService _eventService;
        private readonly AddEventViewModel _addViewModel;
        private readonly EventViewModel _eventViewModel;
        private readonly IDateMediator _dateMediator;

        public AddEventCommand(EventService eventService, AddEventViewModel addEventViewModel, EventViewModel eventViewModel, IDateMediator dateMediator)
        {
            _eventService = eventService;
            _addViewModel = addEventViewModel;
            _eventViewModel = eventViewModel;
            _dateMediator = dateMediator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            if (!ValidateFields())
            {
                // Подсветить текстбоксы с ошибками
                _addViewModel.IsEventDateValid = false;  // Убедитесь, что это обновит UI
                _addViewModel.IsEventNameValid = !string.IsNullOrWhiteSpace(_addViewModel.EventName);
                return;
            }

            var newContact = new DisplayEventModel
            {
                EventName = _addViewModel.EventName,
                EventDate = _addViewModel.EventDate,
                EventTypeName = _addViewModel.EventType?.EventTypeName ?? string.Empty,
            };

            await _eventService.AddEventAsync(newContact, _addViewModel);
            _eventViewModel.LoadEvents();

            _dateMediator.UpdateDate(_addViewModel.EventDate);

            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public bool ValidateFields()
        {
            return _addViewModel.IsEventDateValid && !string.IsNullOrWhiteSpace(_addViewModel.EventName);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
