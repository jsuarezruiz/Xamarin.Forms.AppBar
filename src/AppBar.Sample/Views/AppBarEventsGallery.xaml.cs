using System;
using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class AppBarEventsGallery : ContentPage
    {
        public AppBarEventsGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnFavouriteTapped(object sender, EventArgs e)
        {
            DisplayAlert("AppBarEventsGallery", "OnFavouriteTapped", "Ok");
        }

        void OnSearchTapped(object sender, EventArgs e)
        {
            DisplayAlert("AppBarEventsGallery", "OnSearchTapped", "Ok");
        }

        void OnAppBarBackTapped(object sender, EventArgs e)
        {
            DisplayAlert("AppBarEventsGallery", "OnAppBarBackTapped", "Ok");
        }
    }
}