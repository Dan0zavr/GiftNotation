using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace GiftNotation.Views
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString("dd.MM.yyyy");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string input && DateTime.TryParseExact(input, "dd.MM.yyyy", culture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            return DependencyProperty.UnsetValue; // Возвращает "невалидное" значение
        }
    }
}
