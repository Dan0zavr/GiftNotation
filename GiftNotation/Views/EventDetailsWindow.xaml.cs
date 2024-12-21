using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для EventDetailsWindow.xaml
    /// </summary>
    public partial class EventDetailsWindow : Window
    {
        public EventDetailsWindow()
        {
            InitializeComponent();

        }

        private void ChangedZhach(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            MessageBox.Show(textBox.Text);
        }



        private void Button_Soxran(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public List<string> Tip_prasdnikaaaaa = new List<string>()
        {
            "Новый год",
            "День Рождения",
            "8 марта",
            "23 февраля",
            "Годовщина"
        };
        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получение выбранного типа отношения
            if (Tip_prasdnicaa.SelectedItem != null)
            {
                Tip_prasdnicaa.SelectedItem.ToString();
            }
        }

        private void Button_PlusPeople_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_PlusGifts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void LostFocus_Calendar(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = string.Empty;
            }
        }

        private void GotFocus_Calendar(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = string.Empty;
            }
        }


    }
}
