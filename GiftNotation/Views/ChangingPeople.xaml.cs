using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для ChangingPeople.xaml
    /// </summary>
    public partial class ChangingPeople : Window
    {


        public ChangingPeople()
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

        private void ButtonAdd_ClosePeople(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}