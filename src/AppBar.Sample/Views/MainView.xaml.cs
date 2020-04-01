using System;
using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        void OnBasicAppBarBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasicAppBarGallery());
        }

        void OnAddRemoveToolBarItemsBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRemoveToolBarItemsGallery());
        }

        void OnEnableDisableToolBarItemsBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EnableDisableToolBarItemsGallery());
        }

        void OnUpdateToolBarItemBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateToolBarItemGallery());
        }

        void OnAppBarEventsBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppBarEventsGallery());
        }

        void OnAppBarHeightBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppBarHeightGallery());
        }

        void OnAppBarBackgroundImageBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BackgroundImageGallery());
        }

        void OnTitleViewBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TitleViewGallery());
        }

        void OnScrollBehaviorBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollBehaviorGallery());
        }

        void OnPopupBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupGallery());
        }
    }
}