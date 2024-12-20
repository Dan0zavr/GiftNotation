using GiftNotation.Commands;
using GiftNotation.State.Navigators;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public ICommand UpdateCurrentVMCommand { get; }
        public ICommand OpenCloseFilterCommand { get; }

        public MainViewModel(INavigator navigator, UpdateCurrentVMCommand updateCurrentVMCommand, OpenCloseFilterCommand openCloseFilterCommand)
        {
            Navigator = navigator;
            OpenCloseFilterCommand = openCloseFilterCommand;
            UpdateCurrentVMCommand = navigator.UpdateCurrentVMCommand;
            UpdateCurrentVMCommand.Execute(ViewType.Calendar);
        }
    }
}
