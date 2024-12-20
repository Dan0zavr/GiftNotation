using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Commands.GiftCommands
{
    public class AddGiftCommand : ICommand
    {
        private readonly GiftService _giftService;
        private readonly GiftViewModel _viewModelDisplay;
        private readonly AddGiftViewModel _addGiftViewModel;

        public AddGiftCommand(GiftService giftService, AddGiftViewModel addGiftViewModel, GiftViewModel viewModelDisplay)
        {
            _giftService = giftService;
            _addGiftViewModel = addGiftViewModel;
            _viewModelDisplay = viewModelDisplay;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(_addGiftViewModel.GiftName);
        }

        public async void Execute(object? parameter)
        {

            var newGift = new DisplayGiftModel
            {
                GiftName = _addGiftViewModel.GiftName ?? string.Empty,
                Description = _addGiftViewModel.Description ?? string.Empty,
                Url = _addGiftViewModel.Url ?? string.Empty,
                Price = _addGiftViewModel.Price,
                GiftPic = _addGiftViewModel.GiftPic ?? string.Empty,
                SelectedEventId = _addGiftViewModel.SelectedEvent?.EventId ?? null,
                EventName = _addGiftViewModel.SelectedEvent?.EventName,
                SelectedContactId = _addGiftViewModel.SelectedContact?.ContactId ?? null,
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
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
