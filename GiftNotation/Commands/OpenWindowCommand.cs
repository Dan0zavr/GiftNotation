using GiftNotation.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GiftNotation.Commands
{
    public class OpenWindowCommand<TViewModel> : ICommand where TViewModel : ViewModelBase
    {
        private readonly Func<TViewModel> _viewModelFactory;

        public OpenWindowCommand(Func<TViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; // Команда всегда доступна
        }

        public void Execute(object? parameter)
        {
            // Создаем окно
            var window = new Window
            {
                Title = typeof(TViewModel).Name, // Можно изменить на более осмысленное название
                Content = new ContentControl
                {
                    DataContext = _viewModelFactory.Invoke()
                },
            };

            // Показываем окно
            window.ShowDialog();
        }
    }
}
