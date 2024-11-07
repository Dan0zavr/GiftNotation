using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GiftNotation.State.Navigators;
using GiftNotation.ViewModels;

namespace GiftNotation.Commands
{
    public class UpdateCurrentVMCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentVMCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                switch (viewType)
                {
                    case ViewType.Calendar:
                        _navigator.CurrentViewModel = new CalendarViewModel();
                        break;

                    case ViewType.MyFriends:
                        _navigator.CurrentViewModel  = new MyFriendsViewModel();
                        break;

                    default:
                        break;


                }

            }
        }
    }
}
