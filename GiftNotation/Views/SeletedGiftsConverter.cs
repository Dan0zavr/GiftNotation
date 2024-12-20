using GiftNotation.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GiftNotation.Views
{
    public class SelectedGiftsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedGifts = values[0] as ObservableCollection<Gifts>;
            return selectedGifts != null ? string.Join(", ", selectedGifts.Select(g => g.GiftName)) : string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue };
        }

    }

}
