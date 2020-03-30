using System;
using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class UpdateToolBarItemGallery : ContentPage
    {
        public UpdateToolBarItemGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnChangeIconClicked(object sender, EventArgs e)
        {
            FavToolbarItem.IconImageSource = "search.png";
        }

        void OnRemoveIconClicked(object sender, EventArgs e)
        {
            FavToolbarItem.IconImageSource = null;
        }

        void OnChangeTextClicked(object sender, EventArgs e)
        {
            FavToolbarItem.Text = "Search";
        }

        void OnClearTextClicked(object sender, EventArgs e)
        {
            FavToolbarItem.Text = string.Empty;
        }

        void OnFavToolbarItemClicked(object sender, EventArgs e)
        {
            DisplayAlert("UpdateToolBarItemGallery", "OnFavToolbarItemClicked", "Ok");
        }
    }
}