using GiftNotation.Services;
using System.Windows.Input;

namespace GiftNotation.Commands
{
    public class OpenCloseFilterCommand : ICommand
    {
        private readonly FilterWindowService _filterWindowService;

        public OpenCloseFilterCommand(FilterWindowService filterWindowService)
        {
            _filterWindowService = filterWindowService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            // Если окно фильтров уже открыто, закрываем его. Иначе - открываем.
            if (_filterWindowService.CurrentFiltersWindow?.IsVisible == true)
            {
                _filterWindowService.CloseFilterWindow();
            }
            else
            {
                _filterWindowService.OpenFilterWindow();
            }
        }

        public void CloseFilters()
        {
            _filterWindowService.CloseFilterWindow();
        }
    }
}
