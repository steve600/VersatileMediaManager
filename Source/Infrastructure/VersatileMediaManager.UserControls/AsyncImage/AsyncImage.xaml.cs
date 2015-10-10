using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VersatileMediaManager.UserControls
{
    /// <summary>
    /// Interaktionslogik für AsyncImage.xaml
    /// </summary>
    public partial class AsyncImage : UserControl
    {
        public AsyncImage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The image source
        /// </summary>
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(AsyncImage), new PropertyMetadata("", OnImageSourceChanged));

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AsyncImage v = d as AsyncImage;
            if (v == null)
                return;

            if (e.NewValue != null)
                v.ShowImageAsync(e.NewValue.ToString());
        }

        protected async void ShowImageAsync(string source)
        {
            img.Source = await LoadImageSourceAsync(source);
        }

        private async Task<ImageSource> LoadImageSourceAsync(string address)
        {
            ImageSource imgSource = null;

            try
            {
                string url = EncodeUrl(address);
                MemoryStream ms = new MemoryStream(await new WebClient().DownloadDataTaskAsync(new Uri(url)));
                ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                imgSource = (ImageSource)imageSourceConverter.ConvertFrom(ms);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            return imgSource;
        }

        private string EncodeUrl(string address)
        {
            string adr = address.Replace(@"image://", "");
            adr = System.Web.HttpUtility.UrlDecode(adr);
            return adr;
        }
    }
}