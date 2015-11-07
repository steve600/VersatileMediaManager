using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VersatileMediaManager.Infrastructure.Converter
{
    public static class Converter
    {
        public static IValueConverter FlyoutHeightConverter = new FlyoutHeightConverter();
    }
}
