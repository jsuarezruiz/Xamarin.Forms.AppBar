using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class ScrollBehaviorGallery : ContentPage
    {
        public ScrollBehaviorGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}