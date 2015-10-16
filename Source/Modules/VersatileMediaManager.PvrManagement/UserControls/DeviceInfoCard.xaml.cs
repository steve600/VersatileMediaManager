using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;

namespace VersatileMediaManager.PvrManagement.UserControls
{
    /// <summary>
    /// Interaktionslogik für DeviceInfo.xaml
    /// </summary>
    public partial class DeviceInfoCard : Card
    {
        public DeviceInfoCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Device-Information
        /// </summary>
        public DeviceInfo DeviceInformation
        {
            get { return (DeviceInfo)GetValue(DeviceInformationProperty); }
            set { SetValue(DeviceInformationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeviceInformation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeviceInformationProperty =
            DependencyProperty.Register("DeviceInformation", typeof(DeviceInfo), typeof(DeviceInfoCard), new PropertyMetadata(null));

    }
}
