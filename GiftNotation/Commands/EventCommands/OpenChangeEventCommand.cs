using GiftNotation.Services;
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
    public class OpenChangeEventCommand : ICommand
    {
        private readonly EventViewModel _viewModel;
        private readonly EventService _eventService;

        public OpenChangeEventCommand(EventViewModel viewModel, EventService eventService)
        {
            _viewModel = viewModel;
            _eventService = eventService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedEvent != null;
        }

        public void Execute(object? parameter)
        {
            var changeContactViewModel = new ChangeEventViewModel(_eventService, _viewModel);
            var changeContactWindow = new ChangeEvent
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
