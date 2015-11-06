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

namespace VersatileMediaManager.PvrManagement.Views
{
    /// <summary>
    /// Interaktionslogik für TimerListCard.xaml
    /// </summary>
    public partial class TimerListCard : Card
    {
        public TimerListCard()
        {
            InitializeComponent();
        }

        public TimerList TimerList
        {
            get { return (TimerList)GetValue(TimerListProperty); }
            set { SetValue(TimerListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimerList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimerListProperty =
            DependencyProperty.Register("TimerList", typeof(TimerList), typeof(TimerListCard), new PropertyMetadata(null));


    }
}
