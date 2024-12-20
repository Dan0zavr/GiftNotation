using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для AddGifts.xaml
    /// </summary>
    public partial class AddPeoples : Window
    {
        public AddPeoples()
        {
            InitializeComponent();
        }

        private void ButtonAdd_ClosePeople(object sender, RoutedEventArgs e)
        {
            this.Close();
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
