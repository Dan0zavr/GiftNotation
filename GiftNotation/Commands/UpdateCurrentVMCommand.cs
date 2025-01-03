﻿using GiftNotation.Services;
using GiftNotation.State.Navigators;
using GiftNotation.ViewModels.Factories;
using System.Windows.Input;

namespace GiftNotation.Commands
{
    public class UpdateCurrentVMCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IGiftNotationViewModelAbstractFactory _viewModelFactory;
        private readonly FilterWindowService _filterWindowService;

        public UpdateCurrentVMCommand(INavigator navigator, IGiftNotationViewModelAbstractFactory viewModelFactory, FilterWindowService filterWindowService)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _filterWindowService = filterWindowService;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _filterWindowService.CloseFilterWindow();

            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }

}
