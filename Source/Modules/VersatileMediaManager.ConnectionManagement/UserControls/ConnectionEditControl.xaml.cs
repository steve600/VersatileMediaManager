using System.Windows;
using System.Windows.Controls;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.ConnectionManagement.UserControls
{
    /// <summary>
    /// Interaktionslogik für ConnectionEditControl.xaml
    /// </summary>
    public partial class ConnectionEditControl : UserControl
    {
        public ConnectionEditControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The connection
        /// </summary>
        public IConnection Connection
        {
            get { return (IConnection)GetValue(ConnectionProperty); }
            set { SetValue(ConnectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Connection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConnectionProperty =
            DependencyProperty.Register("Connection", typeof(IConnection), typeof(ConnectionEditControl), new PropertyMetadata(null));

        /// <summary>
        /// The connection kind
        /// </summary>
        public ConnectionKindsEnum? ConnectionKind
        {
            get { return (ConnectionKindsEnum?)GetValue(ConnectionKindProperty); }
            set { SetValue(ConnectionKindProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConnectionKind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConnectionKindProperty =
            DependencyProperty.Register("ConnectionKind", typeof(ConnectionKindsEnum?), typeof(ConnectionEditControl), new PropertyMetadata(null));

        /// <summary>
        /// Connection type
        /// </summary>
        public ConnectionTypesEnum? ConnectionType
        {
            get { return (ConnectionTypesEnum)GetValue(ConnectionTypeProperty); }
            set { SetValue(ConnectionTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConnectionType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConnectionTypeProperty =
            DependencyProperty.Register("ConnectionType", typeof(ConnectionTypesEnum?), typeof(ConnectionEditControl), new PropertyMetadata(null));
    }
}