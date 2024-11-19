using GiftNotation.Data;
using GiftNotation.Models;
using GiftNotation.Services;
using GiftNotation.State;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace GiftNotation.ViewModels
{
    public class GiftViewModel : ViewModelBase
    {
        private ObservableCollection<Gifts> _gifts;
        private GiftService _giftService;

        public ObservableCollection<Gifts> Gifts
        {
            get { return _gifts; }
            set { SetProperty(ref _gifts, value); }
        }

        public GiftViewModel(GiftService giftService)
        {
            _giftService = giftService;
            // Загрузка данных из базы данных или другого источника
            LoadGifts();
        }

        private async void LoadGifts()
        {
            // Здесь вы можете подключиться к базе данных через сервис или репозиторий
            var gifts = await _giftService.GetGiftsAsync(); // Это пример, ваш метод получения данных
            Gifts = new ObservableCollection<Gifts>(gifts);
        }

    }
}
