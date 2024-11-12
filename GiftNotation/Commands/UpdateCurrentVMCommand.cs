using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GiftNotation.Services;
using GiftNotation.State.Navigators;
using GiftNotation.ViewModels;

namespace GiftNotation.Commands
{
    public class UpdateCurrentVMCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IMyFriendsService _friendsService;

        // Конструктор команды, принимающий INavigator и IMyFriendsService через DI
        public UpdateCurrentVMCommand(INavigator navigator, IMyFriendsService friendsService)
        {
            _navigator = navigator;
            _friendsService = friendsService;
        }

        // Команда доступна для выполнения всегда
        public bool CanExecute(object? parameter) => true;

        // Выполняется при нажатии на кнопку в панели управления
        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Calendar:
                        // Создание новой модели представления для Calendar
                        _navigator.CurrentViewModel = new CalendarViewModel();
                        break;

                    case ViewType.MyFriends:
                        // Создание MyFriendsViewModel с использованием переданного сервиса
                        _navigator.CurrentViewModel = new MyFriendsViewModel(_friendsService);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
