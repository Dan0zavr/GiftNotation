using GiftNotation.ViewModels;
using System.Windows.Input;

namespace GiftNotation.Commands.ContactCommands
{
    public class AddGiftForContactOnAddCommand : ICommand
    {
        private readonly AddContactViewModel _viewModel;

        public AddGiftForContactOnAddCommand(AddContactViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedGift != null;
        }

        public void Execute(object? parameter)
        {
            AddGiftForContact();
        }

        private void AddGiftForContact()
        {
            var contact = _viewModel.SelectedGift;
            if (contact != null)
            {
                _viewModel.GiftsForContact.Add(contact);
                _viewModel.Gifts.Remove(contact); // Удаление из общего списка
                _viewModel.SelectedGift = null;  // Сброс выбора контакта
            }
        }

        // Уведомляем привязку, что состояние команды могло измениться
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
