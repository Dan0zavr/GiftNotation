using GiftNotation.Commands;
using GiftNotation.GlobalFunctions;
using GiftNotation.Services;
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
        //Создание экзкмпляра класса ViewModelBase
        private ViewModelBase _currentViewModel;
        private readonly IMyFriendsService _friendsService;

        public Navigator(IMyFriendsService friendsService)
        {
            _friendsService = friendsService;
        }


        public ViewModelBase CurrentViewModel
        {
            get
            {
                //Получаем текущую модель представления
                return _currentViewModel;
            }
            set { 
                //Устанавливаем текущую модель представления и сообщаем об изменении
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        //Команда выполняющаяся при нажатии на кнопку
        public ICommand UpdateCurrentVMCommand => new UpdateCurrentVMCommand(this, _friendsService);

        
    }
}
