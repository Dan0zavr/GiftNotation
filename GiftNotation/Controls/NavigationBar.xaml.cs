﻿using System.Windows;
using System.Windows.Controls;

namespace GiftNotation.Controls
{
    /// <summary>
    /// Логика взаимодействия для NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Завершает работу приложения
        }


        private void Button_minim(object sender, RoutedEventArgs e)
        {

            var rodWindows = Window.GetWindow(this);
            if (rodWindows != null)
            {
                rodWindows.WindowState = WindowState.Minimized;

            }
        }


    }
}
