using System.Windows;
using System.Windows.Controls;
using VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details;

namespace VersatileMediaManager.KodiManagement.UserControls
{
    /// <summary>
    /// Interaktionslogik für MovieListViewEntry.xaml
    /// </summary>
    public partial class MovieListViewEntry : UserControl
    {
        public MovieListViewEntry()
        {
            InitializeComponent();
        }

        public Movie Movie
        {
            get { return (Movie)GetValue(MovieProperty); }
            set { SetValue(MovieProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Movie.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MovieProperty =
            DependencyProperty.Register("Movie", typeof(Movie), typeof(MovieListViewEntry), new PropertyMetadata(null));
    }
}