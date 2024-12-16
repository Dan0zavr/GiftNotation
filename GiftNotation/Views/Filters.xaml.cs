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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
