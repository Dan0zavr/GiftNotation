using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftNotation.ViewModels
{
    public class GiftViewModel : ViewModelBase
    {
        private string _giftName;
        private string _description;
        private string _url;
        private double _price;
        private string _picture;

        public string GiftName
        {
            get 
            {
                return _giftName; 
            }
            set 
            {
                _giftName = value; 
                OnPropertyChanged(nameof(GiftName));
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(URL));
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(Picture));
            }
        }

        ICommand AddGiftCommand { get; set; }
        ICommand DeleteGiftCommand { get; set; }
        ICommand EditGiftCommand { get; set; }

    }
}
