using MahApps.Metro.Controls;
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
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.PvrManagement.Views
{
    /// <summary>
    /// Interaktionslogik für PvrManagementFlyout.xaml
    /// </summary>
    public partial class PvrManagementFlyout : Flyout, IFlyoutView
    {
        public PvrManagementFlyout()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// The flyout name
        /// </summary>
        public string FlyoutName
        {
            get
            {
                return FlyoutNames.PvrManagementFlyout;
            }
        }
    }
}
