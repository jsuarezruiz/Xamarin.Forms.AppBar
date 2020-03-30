using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class TitleViewGallery : ContentPage
    {
        public TitleViewGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}