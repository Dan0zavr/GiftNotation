using GiftNotation.ViewModels.GiftViewModels;
using System.Windows.Input;


namespace GiftNotation.Commands.GiftCommands
{
    public class OpenFileDialogForPictureCommand : ICommand
    {
        private IAddOrEditGiftViewModel _giftViewModel;

        public OpenFileDialogForPictureCommand(IAddOrEditGiftViewModel giftViewModel)
        {
            _giftViewModel = giftViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            // Используем OpenFileDialog для выбора изображения
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Выберите изображение"
            };

            if (dialog.ShowDialog() == true)
            {
                _giftViewModel.GiftPic = dialog.FileName;
            }
        }

    }

}
