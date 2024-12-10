using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GiftNotation.Views
{
    public class LookupConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not DateTime date || values[1] is not HashSet<DateTime> dates)
                return false;

            bool contains = dates.Contains(date.Date); // Убедитесь, что сравниваются только даты
            Console.WriteLine($"Date: {date}, Contains: {contains}");
            return contains;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
