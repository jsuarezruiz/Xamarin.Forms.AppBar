using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class BasicAppBarGallery : ContentPage
    {
        public BasicAppBarGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}