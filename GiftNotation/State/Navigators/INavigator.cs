using GiftNotation.ViewModels;
using System.Windows.Input;

namespace GiftNotation.State.Navigators
{
    //Перечисление страниц
    public enum ViewType
    {
        Calendar,
        Contacts,
        Events,
        Gifts
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentVMCommand { get; }

        event Action CurrentViewModelChanged;
    }
}
