using System.Windows;
using System.Windows.Input;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для Filters.xaml
    /// </summary>
    public partial class Filters : Window
    {
        public Filters()
        {
            InitializeComponent();
        }

        private void ButtonAdd_CloseFilter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void W_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
