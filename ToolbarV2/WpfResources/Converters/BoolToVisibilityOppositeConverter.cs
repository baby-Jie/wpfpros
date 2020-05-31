using System;
using System.Windows;
using System.Windows.Data;

namespace WpfResources.Converters
{
    public class BoolToVisibilityOppositeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool visible = false;
            if (bool.TryParse(value.ToString(), out visible))
            {
                if (visible)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
