using GiftNotation.Commands;
using GiftNotation.Services;
using GiftNotation.ViewModels;
using GiftNotation.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GiftNotation.Views;

namespace GiftNotation.State.Navigators
{


    public class Navigator : INavigator, INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;
        private FilterWindowService _filterWindowService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));
                    OnCurrentViewModelChanged();
                }
            }
        }

        public ICommand UpdateCurrentVMCommand { get; set; }

        public event Action CurrentViewModelChanged;

        public Navigator(IGiftNotationViewModelAbstractFactory viewModelFactory, FilterWindowService filterWindowService)
        {
            _filterWindowService = filterWindowService;
            UpdateCurrentVMCommand = new UpdateCurrentVMCommand(this, viewModelFactory, _filterWindowService);

        }

        protected virtual void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
        

