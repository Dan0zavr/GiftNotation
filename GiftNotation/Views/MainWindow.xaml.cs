using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GiftNotation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

        }

        //private void TabControl_Obrabotka1(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void TabControl_Obrabotka2(object sender, SelectionChangedEventArgs e)
        //{

        //}


        //private void Button_ClickVish_List(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new Uri("Page3.xaml", UriKind.Relative));
        //}

        //private void Button_Click_MyFriends(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new Uri("People.xaml", UriKind.Relative));
        //}

        //private void Button_Click_MyProfil(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new Uri("Profil.xaml", UriKind.Relative));
        //}

        //private void Button_Click_Setting(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new Uri("Setting.xaml", UriKind.Relative));
        //}

        //private void Button_Home(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.Show();
        //    Window.GetWindow(this)?.Close();
        //}

        //private void Button_Gifts(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new Uri("Gifts.xaml", UriKind.Relative));
        //}

        //private void DateEnterNewEvent(object sender, SelectionChangedEventArgs e)
        //{
        //    if (eventCalendar.SelectedDate.HasValue)
        //    {
        //        DateTime selectedDate = eventCalendar.SelectedDate.Value;

        //        ////EventDetailsWindow newWindow = new EventDetailsWindow(selectedDate);
        //        //newWindow.Show();

        //    }
        //}


        //private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        //{

        //}

        //private void PageFrame_Navigated(object sender, NavigationEventArgs e)
        //{

        //}
    }

    public partial class FriendsWindow : Window
    {

    }




}
