using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace виш_лист_попытка_33334
{

    public class PathToImageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string path && !string.IsNullOrEmpty(path))
            {
                return new BitmapImage(new Uri(path));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; //Для двустороннего преобразования
        }
    }
}
