using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VersatileMediaManager.Infrastructure.Converter
{
    public class UnixDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                long seconds = 0;

                if (long.TryParse(value.ToString(), out seconds))
                {
                    return DateTimeOffset.FromUnixTimeSeconds(System.Convert.ToInt64(seconds)).LocalDateTime;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
