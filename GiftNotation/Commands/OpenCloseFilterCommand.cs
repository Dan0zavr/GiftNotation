using GiftNotation.Services;
using GiftNotation.State.Navigators;
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
        private readonly FilterWindowService _filterWindowService;

        public OpenCloseFilterCommand(FilterWindowService filterWindowService)
        {
            _filterWindowService = filterWindowService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {

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
