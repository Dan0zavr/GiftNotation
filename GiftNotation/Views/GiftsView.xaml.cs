using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace GiftNotation.Views;

/// <summary>
/// Логика взаимодействия для Page2.xaml
/// </summary>
public partial class GiftsView : UserControl { 

    //public ObservableCollection<Gifts> Giftss { get; set; }
    public GiftsView()
    {
        
        InitializeComponent();

        //Giftss = new ObservableCollection<Gifts>();
        //DataContext = this;
    }

    //public void AddGifts(string name_gift, string picture_of_gift, string cost, string ssylka_na_market, string people_, string event_)
    //{
    //    Giftss.Add(new Gifts { Name_gift = name_gift, Picture_of_gift = picture_of_gift, Cost = cost, Ssylka_na_market = ssylka_na_market, People_ = people_, Event_ = event_ });
    //}

    //public void DdataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
    //{
    //    if(e.Key == Key.Enter)
    //    {
    //        var ddataGrid = sender as DataGrid;
    //        if(ddataGrid != null)
    //        {
    //            ddataGrid.CommitEdit();
    //            ddataGrid.BeginEdit();
    //            e.Handled = false;
    //        }
    //    }
    //}

    
}
