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
    public class OpenAddEventCommand : ICommand
    {
        
        private readonly EventService _eventService;
        private readonly EventViewModel _viewModel;

        public OpenAddEventCommand(EventService eventService, EventViewModel eventViewModel)
        {
            _eventService = eventService;
            _viewModel = eventViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var addEventViewModel = new AddEventViewModel(_eventService, _viewModel);
            var addEventWindow = new AddEvent
            {
                DataContext = addEventViewModel
            };

            addEventWindow.ShowDialog();
        }
    }
}
