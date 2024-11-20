using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System;

namespace виш_лист_попытка_3334
{

    public class Gifts : INotifyPropertyChanged
    {
        private string name_gift;
        private BitmapImage picture_of_gift;
        private string cost;
        private string ssylka_na_market;
        private string people_;
        private string event_;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name_gift
        {
            get { return name_gift; }
            set
            {
                if (name_gift != value)
                {
                    name_gift = value;
                    OnPropertyChanged(nameof(Name_gift));
                }
            }
        }

        public BitmapImage Picture_of_gift
        {
            get => picture_of_gift;
            set
            {
                if (picture_of_gift != value)
                {
                    picture_of_gift = value;
                    OnPropertyChanged(nameof(Picture_of_gift));
                }
            }
        }

        public string Cost
        {
            get => cost;
            set
            {
                if (cost != value)
                {
                    cost = value;
                    OnPropertyChanged(nameof(Cost));
                }
            }
        }

        public string Ssylka_na_market
        {
            get => ssylka_na_market;
            set
            {
                if (ssylka_na_market != value)
                {
                    ssylka_na_market = value;
                    OnPropertyChanged(nameof(Ssylka_na_market));
                }
            }
        }

        public string People_
        {
            get => people_;
            set
            {
                if (people_ != value)
                {
                    people_ = value;
                    OnPropertyChanged(nameof(People_));
                }
            }
        }

        public string Event_
        {
            get => event_;
            set
            {
                if (event_ != value)
                {
                    event_ = value;
                    OnPropertyChanged(nameof(Event_));
                }
            }
        }

        private void Image(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var gift = button?.Tag as Gifts;

            if(gift == null)
            {
                return;
            }

            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Image Files|*.ipeg;*ipg;*png;*bmp",
                Title = "Выберите изображение"
            };

            if(openFileDialog.ShowDialog() == true)
            {
                var image = new BitmapImage(new System.Uri(openFileDialog.FileName));
                gift.Picture_of_gift = image;
            }
        }
        private void DataGrid_CellEditingTemplate(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Image")
            {
                var gift = e.Row.Item as Gifts;
                if (gift != null)
                {
                    var openFileDialog = new Microsoft.Win32.OpenFileDialog()
                    {
                        Filter = "Image Files|*.jpg;*jpeg;*png;*bmp",
                        Title = "Выберите изображение"
                    };

                    if (openFileDialog.ShowDialog() == true)
                    {
                        var image = new BitmapImage(new Uri(openFileDialog.FileName));
                        gift.Picture_of_gift = image;
                    }
                }
            }
        }
    }
}

