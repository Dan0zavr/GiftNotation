using GiftNotation.Commands;
using GiftNotation.GlobalFunctions;
using GiftNotation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.State.Navigators
{
    

    public class Navigator : NotifyObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set { 
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentVMCommand => new UpdateCurrentVMCommand(this);

        
    }
}
