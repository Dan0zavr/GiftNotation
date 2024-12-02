using GiftNotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftNotation.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private string _name;
        private DateTime _bday;

        

        public string ContactName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(ContactName));
            }
        }

        public DateTime Bday
        {
            get
            {
                return _bday;
            }
            set
            {
                _bday = value;
                OnPropertyChanged(nameof(Bday));
            }
        }

        
    }
}
