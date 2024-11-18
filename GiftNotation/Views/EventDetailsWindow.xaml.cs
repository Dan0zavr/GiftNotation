using System;
using System.Collections.Generic;
using System.Data;
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

namespace виш_лист_попытка_33334
{
    /// <summary>
    /// Логика взаимодействия для EventDetailsWindow.xaml
    /// </summary>
    public partial class EventDetailsWindow : Window
    {
        public EventDetailsWindow(DateTime selectedDate)
        {
            InitializeComponent();
            EnterDate.Text = selectedDate.ToString("D");
            Tip_prasdnicaa.ItemsSource = Tip_prasdnikaaaaa;

        }

        private void ChangedZhach(object sender, TextChangedEventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //MessageBox.Show(textBox.Text);
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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получение выбранного типа отношения
            if (Tip_prasdnicaa.SelectedItem != null)
            {
                Tip_prasdnicaa.SelectedItem.ToString();
            }
        }
    }
}
