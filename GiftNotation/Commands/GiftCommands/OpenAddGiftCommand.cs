using GiftNotation.Services;
using GiftNotation.ViewModels;
using GiftNotation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.Commands.GiftCommands
{
    public class OpenAddGiftCommand : ICommand
    {
        private readonly GiftViewModel _viewModel;
        private readonly GiftService _giftService;
        private readonly EventService _eventService;
        private readonly StatusService _statusService;
        private readonly ContactService _contactService;

        public OpenAddGiftCommand(GiftViewModel viewModel, GiftService giftService, StatusService statusService)
        {
            _viewModel = viewModel;
            _giftService = giftService;
            _statusService = statusService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var addGiftViewModel = new AddGiftViewModel(_giftService, _viewModel, _statusService);
            var addGiftWindow = new AddGifts
            {
                DataContext = addGiftViewModel
            };

            addGiftWindow.ShowDialog();
        }
    }
}
