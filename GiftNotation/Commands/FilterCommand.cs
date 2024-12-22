using GiftNotation.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Commands
{
    public class FilterCommand : ICommand
    {
        private readonly FiltersViewModel _viewModel;

        public FilterCommand(FiltersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _viewModel.ApplyFilters();

            if (parameter is Window window)
            {
                window.Close();
            }
        }
    }

}
