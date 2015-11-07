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
            if (value != null && value is long)
            {
                return DateTimeOffset.FromUnixTimeSeconds(System.Convert.ToInt64(value));
                //DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                //double unixTime = System.Convert.ToDouble(value);

                //if (unixTime > 0)
                //{
                //    return result.AddSeconds(unixTime).ToLocalTime();
                //}
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
