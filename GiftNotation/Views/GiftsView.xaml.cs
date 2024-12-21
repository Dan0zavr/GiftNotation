using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GiftNotation.Views;

/// <summary>
/// Логика взаимодействия для Page2.xaml
/// </summary>
public partial class GiftsView : UserControl
{

    //public ObservableCollection<Gifts> Giftss { get; set; }
    public GiftsView()
    {

        InitializeComponent();

        //Giftss = new ObservableCollection<Gifts>();
        //DataContext = this;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddGifts addGifts = new AddGifts();
        addGifts.Show();
    }

    private void Button_Changing(object sender, RoutedEventArgs e)
    {
        ChangingGifts changingGifts = new ChangingGifts();
        changingGifts.Show();
    }

    private void Button_Add(object sender, RoutedEventArgs e)
    {
        AddGifts addGifts = new AddGifts();
        addGifts.Show();
    }

    private void Button_Delete(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {

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

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        // Попытка создания URI из строки, чтобы проверить, является ли она ссылкой
        Uri uri;
        bool isValidUri = Uri.TryCreate(e.Uri.ToString(), UriKind.Absolute, out uri);

        if (isValidUri)
        {
            try
            {
                // Пытаемся открыть ссылку
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // Обработка ошибки, если ссылка не может быть открыта
                MessageBox.Show("Ошибка при открытии ссылки: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        else
        {
            // Если это не ссылка, игнорируем переход
            e.Handled = true;
        }
    }



}
