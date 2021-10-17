using System;
using System.Globalization;
using System.Windows.Data;

namespace DesktopUI.Converters
{
    public class StringToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            var date = DateTime.Parse(value.ToString());
            return $"{date.ToShortDateString()}";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
