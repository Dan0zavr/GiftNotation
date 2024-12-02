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
        private ObservableCollection<DisplayGiftModel> _gifts;
        private GiftService _giftService;

        private int _giftId;
        private string _giftName;
        private string _giftDescription;
        private string _url;
        private double _price;
        private string _giftPic;
        private string _statusName;
        private string _contactName;
        private string _eventName;

        public int GiftId
        {
            get { return _giftId; }
            set
            {
                _giftId = value;
                OnPropertyChanged(nameof(GiftId));
            }
        }

        public string GiftName
        {
            get { return _giftName; }
            set
            {
                _giftName = value;
                OnPropertyChanged(nameof(GiftName));
            }
        }

        public string Description
        {
            get { return _giftDescription; }
            set
            {
                _giftDescription = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Url
        {
            get => _url; set
            {
                _url = value;
                OnPropertyChanged(nameof(Url));
            }
        }
        public double Price
        {
            get => _price; set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string GiftPic
        {
            get => _giftPic; set
            {
                _giftPic = value;
                OnPropertyChanged(nameof(GiftPic));
            }
        }
        public string StatusName
        {
            get => _statusName; set
            {
                _statusName = value;
                OnPropertyChanged(nameof(StatusName));
            }
        }
        public string ContactName
        {
            get => _contactName; set
            {
                _contactName = value;
                OnPropertyChanged(nameof(ContactName));
            }
        }
        public string EventName
        {
            get => _eventName; set
            {
                _eventName = value;
                OnPropertyChanged(nameof(EventName));
            }
        }

        public ObservableCollection<DisplayGiftModel> Gifts
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
            var gifts = await _giftService.GetGiftAsync(); // Это пример, ваш метод получения данных
            Gifts = new ObservableCollection<DisplayGiftModel>(gifts);
        }

    }
}
