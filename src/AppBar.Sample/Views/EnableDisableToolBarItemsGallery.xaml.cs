using System;
using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class EnableDisableToolBarItemsGallery : ContentPage
    {
        public EnableDisableToolBarItemsGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnEnableToolBarItemClicked(object sender, EventArgs e)
        {
            FavToolbarItem.IsEnabled = true;
        }

        void OnDisableToolBarItemClicked(object sender, EventArgs e)
        {
            FavToolbarItem.IsEnabled = false;
        }

        void OnFavToolbarItemClicked(object sender, EventArgs e)
        {
            DisplayAlert("EnableDisableToolBarItemsGallery", "OnFavToolbarItemClicked", "Ok");
        }
    }
}