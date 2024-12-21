﻿using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Commands.EventCommands
{
    public class ChangeEventCommand : ICommand
    {
        private readonly EventService _eventService;
        private readonly ChangeEventViewModel _changeViewModel;
        private readonly EventViewModel _eventViewModel;

        public ChangeEventCommand(EventService eventService, ChangeEventViewModel changeViewModel, EventViewModel eventViewModel)
        {
            _eventService = eventService;
            _changeViewModel = changeViewModel;
            _eventViewModel = eventViewModel;
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
                return;
            }

            var changeEvent = new DisplayEventModel
            {
                EventId = _changeViewModel.EventId,
                EventName = _changeViewModel.EventName,
                EventDate = _changeViewModel.EventDate,
                EventTypeName = _changeViewModel.SelectedEventType?.EventTypeName
            };
            await _eventService.UpdateEventAsync(changeEvent, _changeViewModel);

            _eventViewModel.LoadEvents();

            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public bool ValidateFields()
        {
            return _changeViewModel.IsEventDateValid && !string.IsNullOrWhiteSpace(_changeViewModel.EventName);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
