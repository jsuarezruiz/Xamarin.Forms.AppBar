using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class AppBarHeightGallery : ContentPage
    {
        public AppBarHeightGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
