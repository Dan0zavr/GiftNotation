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
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using GiftNotation.Models;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class People : UserControl
    {
        public ObservableCollection<Contact> Peoples { get; set; }
        
        public People()
        {
            InitializeComponent();

            Peoples = new ObservableCollection<Contact>();
            DataContext = this;
        }

        public void AddPeople(string name, int ship, DateTime birthday/*Gift gift*/)
        {
            Peoples.Add(new Contact { ContactName = name, RelpTypeId = ship, Bday = birthday, /*Gift = gift*/ }) ;
        }

        public void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) //Проверка нажатия клавиши. То есть, если нажата Enter
            {
                var dataGrid = sender as DataGrid;
                if (dataGrid != null && dataGrid.CurrentCell.Column.DisplayIndex == dataGrid.Columns.Count-1)
                {
                    dataGrid.CommitEdit();
                    dataGrid.BeginEdit();
                    e.Handled = false;
                }
            }
        }

        
    }
}
