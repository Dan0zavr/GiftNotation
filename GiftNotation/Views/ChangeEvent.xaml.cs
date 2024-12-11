using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для ChangeEvent.xaml
    /// </summary>
    public partial class ChangeEvent : Window
    {
        public ChangeEvent()
        {
            InitializeComponent();
        }


        private void ButtonChanging_ClosePeople(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonChanging_DonePeople(object sender, RoutedEventArgs e)
        {
            //Тут должна быть привязка к классу Person (MyFriends)
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
