using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VersatileMediaManager.Infrastructure.Converter
{
    public class FlyoutHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double flyoutHeight = 0;

            // Height of title- and status-bar
            double substractHeight = 60.0;

            if (value != null && value is double)
            {
                flyoutHeight = System.Convert.ToDouble(value);

                if (flyoutHeight > substractHeight)
                    flyoutHeight = flyoutHeight - substractHeight;
            }

            return (flyoutHeight > 0) ? flyoutHeight : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
