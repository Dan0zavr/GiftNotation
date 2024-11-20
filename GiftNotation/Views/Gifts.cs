using System.ComponentModel;
namespace GiftNotation.Views;
public class Gifts : INotifyPropertyChanged
{
    private string name_gift;
    private string picture_of_gift;
    private string cost;
    private string ssylka_na_market;
    private string people_;
    private string event_;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string Name_gift
    {
        get => name_gift;
        set
        {
            if (name_gift != value)
            {
                name_gift = value;
                OnPropertyChanged(nameof(Name_gift));
            }
        }
    }

    public string Picture_of_gift
    {
        get => picture_of_gift;
        set
        {
            if (picture_of_gift != value)
            {
                picture_of_gift = value;
                OnPropertyChanged(nameof(Picture_of_gift));
            }
        }
    }

    public string Cost
    {
        get => cost;
        set
        {
            if (cost != value)
            {
                cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
    }

    public string Ssylka_na_market
    {
        get => ssylka_na_market;
        set
        {
            if (ssylka_na_market != value)
            {
                ssylka_na_market = value;
                OnPropertyChanged(nameof(Ssylka_na_market));
            }
        }
    }

    public string People_
    {
        get => people_;
        set
        {
            if (people_ != value)
            {
                people_ = value;
                OnPropertyChanged(nameof(People_));
            }
        }
    }

    public string Event_
    {
        get => event_;
        set
        {
            if (event_ != value)
            {
                event_ = value;
                OnPropertyChanged(nameof(Event_));
            }
        }
    }
}
