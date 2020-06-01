using System;
using System.Globalization;
using System.Windows.Data;

namespace RecordLib.Converters
{
    public class IsStringNullOrSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isEnable = false;

            try
            {
                string str = value.ToString();
                isEnable = !string.IsNullOrWhiteSpace(str);
                if (isEnable)
                {
                    int len = str.Length;
                    if (len > 124)
                    {
                        isEnable = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return isEnable;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
