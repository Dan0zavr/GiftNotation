using System.Windows.Controls;

namespace GiftNotation.Views;

/// <summary>
/// Логика взаимодействия для Page1.xaml
/// </summary>
/// 
public partial class People : UserControl
{


    //Коллекция, которая хранит в себе имена из DataGrid для передачи их в другие страницы и DataGrid OnNamesRequested - метод, возвращающий список имен.
    public event Action<List<string>> OnNamesReceived;
    public People()
    {

        InitializeComponent();

    }






}






//

//public People()
//{
//    InitializeComponent();

//    Peoples = new ObservableCollection<Person>();
//    DataContext = this;
//}

//public Person SelectPeople { get; set; }





//public void AddPeople(string name, string ship, DateTime birthday, string gift)
//{
//    People.Add(new Person { Name = name, Ship = ship, Birthday = birthday, Gift = gift });
//}

//public void datagrid_previewkeydown(object sender, KeyEventArgs e)
//{
//    if (e.Key == Key.Enter) //проверка нажатия клавиши. то есть, если нажата enter
//    {
//        var datagrid = sender as DataGrid;
//        if (datagrid != null && datagrid.CurrentCell.Column.DisplayIndex == datagrid.Columns.Count - 1)
//        {
//            datagrid.CommitEdit();
//            datagrid.BeginEdit();
//            e.Handled = false;
//        }
//    }
//}






