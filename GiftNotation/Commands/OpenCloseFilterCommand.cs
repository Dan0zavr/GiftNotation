using GiftNotation.ViewModels;
using GiftNotation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GiftNotation.Commands
{
    public class OpenCloseFilterCommand : ICommand
    {

        private Window _openWindow;
        private FiltersViewModel _viewModel;

        public OpenCloseFilterCommand(FiltersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
    {
        if (parameter is Button button)
        {
            // Если окно не открыто, создаем и показываем его
            if (_openWindow == null || !_openWindow.IsVisible)
            {
                _openWindow = new Filters
                {
                    // Устанавливаем родительское окно
                    Owner = Application.Current.MainWindow,
                    DataContext = _viewModel,
                    Topmost = false
                };

                // Получаем позицию кнопки на экране относительно родительского окна
                var buttonPosition = button.TransformToAncestor(Application.Current.MainWindow)
                    .Transform(new Point(0, 0));

                // Устанавливаем позицию дочернего окна
                _openWindow.Left = Application.Current.MainWindow.Left + buttonPosition.X;
                _openWindow.Top = Application.Current.MainWindow.Top + buttonPosition.Y + button.Height;

                _openWindow.Show();

                // Подписываемся на событие скрытия родительского окна
                Application.Current.MainWindow.StateChanged += MainWindow_StateChanged;
            }
            else
            {
                // Если окно открыто, скрываем его
                _openWindow.Hide();
            }
        }
    }

    private void MainWindow_StateChanged(object sender, EventArgs e)
    {
        // Если родительское окно скрыто, скрываем и окно фильтров
        if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
        {
            _openWindow.Hide();
        }
        else if (Application.Current.MainWindow.WindowState == WindowState.Normal)
        {
            // Когда родительское окно восстанавливается, показываем окно фильтров
            if (_openWindow != null && !_openWindow.IsVisible)
            {
                _openWindow.Show();
            }
        }
    }



    }
}
