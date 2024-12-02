using GiftNotation.ViewModels;
using GiftNotation.Services;
using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace GiftNotation.Commands.GiftCommands
{
    public class AddGiftCommand : ICommand
    {
        private readonly GiftService _giftService;
        private readonly GiftViewModel _viewModelDisplay;
        private readonly AddGiftViewModel _addGiftViewModel;

        public AddGiftCommand(GiftService giftService, AddGiftViewModel addGiftViewModel,GiftViewModel viewModelDisplay)
        {
            _giftService = giftService;
            _addGiftViewModel = addGiftViewModel;
            _viewModelDisplay = viewModelDisplay;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
    {
           
            var newGift = new DisplayGiftModel
            {
                GiftName = _addGiftViewModel.GiftName ?? string.Empty,
                Description = _addGiftViewModel.Description ?? string.Empty,
                Url = _addGiftViewModel.Url ?? string.Empty,
                Price = _addGiftViewModel.Price ,
                GiftPic = _addGiftViewModel.GiftPic ?? string.Empty,
                EventName = _addGiftViewModel.SelectedEvent?.EventName,
                ContactName = _addGiftViewModel.SelectedContact?.ContactName,
                StatusName = _addGiftViewModel.SelectedStatus?.StatusName

            };

            await _giftService.AddGiftAsync(newGift);

            // Обновляем список подарков после добавления
            _viewModelDisplay.LoadGifts();
            

            if (parameter is Window window)
            {
                window.Close();
            }

        }

    }
}
