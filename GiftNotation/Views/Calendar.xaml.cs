﻿using System;
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
using виш_лист_попытка_33334;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
        }

        private void DateEnterNewEvent(object sender, SelectionChangedEventArgs e)
        {
            if (eventCalendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = eventCalendar.SelectedDate.Value;

                EventDetailsWindow newWindow = new EventDetailsWindow(selectedDate);
                newWindow.Show();

            }
        }


    }
}
