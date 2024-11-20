using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace виш_лист_попытка_33334
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        private DateTime birthday;
        private string gift;
        private string ship;



        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (birthday != value)
                {
                    birthday = value;
                    OnPropertyChanged(nameof(Birthday));
                }
            }
        }
        
        public string Gift
        {
            get { return gift; }
            set
            {
                if (gift != value)
                {
                    gift = value;
                    OnPropertyChanged(nameof(Gift));
                }
            }
        }

        public string Ship
        {
            get => ship;
            set
            {
                if (ship != value)
                {
                    ship = value;
                    OnPropertyChanged(nameof(Ship));
                }
            }
        }

        //реализует механизм уведомления об изменении свойств, который используется для работы с привязками данных в .NET, особенно в пользовательских интерфейсах (например, в WPF). Он позволяет классу сообщать другим частям программы, когда одно из его свойств изменилось
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
