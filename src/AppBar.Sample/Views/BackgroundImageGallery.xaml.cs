using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class BackgroundImageGallery : ContentPage
    {
        public BackgroundImageGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}