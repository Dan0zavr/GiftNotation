using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Commands.GiftCommands
{
    public class ChangeGiftCommand : ICommand
    {
        private readonly GiftService _giftService;
        private readonly GiftViewModel _viewModelDisplay;
        private readonly ChangeGiftViewModel _changeGiftViewModel;

        public ChangeGiftCommand(GiftService giftService, GiftViewModel viewModelDisplay, ChangeGiftViewModel changeGiftViewModel)
        {
            _giftService = giftService;
            _viewModelDisplay = viewModelDisplay;
            _changeGiftViewModel = changeGiftViewModel;
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

            var changeGift = new DisplayGiftModel
            {
                GiftId = _changeGiftViewModel.GiftId,
                GiftName = _changeGiftViewModel.GiftName ?? string.Empty,
                Description = _changeGiftViewModel.Description ?? string.Empty,
                Url = _changeGiftViewModel.Url ?? string.Empty,
                Price = _changeGiftViewModel.Price,
                GiftPic = _changeGiftViewModel.GiftPic ?? string.Empty,
                EventId = _changeGiftViewModel.SelectedEvent?.EventId,
                ContactId = _changeGiftViewModel.SelectedContact?.ContactId,
                StatusName = _changeGiftViewModel.SelectedStatus?.StatusName

            };
            await _giftService.UpdateGiftAsync(changeGift);

            _viewModelDisplay.LoadGifts();

            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public bool ValidateFields()
        {
            _changeGiftViewModel.IsGiftNameValid = !string.IsNullOrWhiteSpace(_changeGiftViewModel.GiftName);
            return _changeGiftViewModel.IsGiftNameValid;
        }
    }
}
