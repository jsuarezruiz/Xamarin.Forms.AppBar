using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.AppBar;

namespace AppBar.Sample.Views
{
    public partial class PopupGallery : ContentPage
	{
		public PopupGallery()
		{
			InitializeComponent();

            PositionPicker.SelectedItem = "Center";
            HeightSlider.Maximum = DeviceDisplay.MainDisplayInfo.Height;
            WidthSlider.Maximum = DeviceDisplay.MainDisplayInfo.Width;
        }

        private void OnShowPopupClicked(object sender, EventArgs e)
        {
            var popup = new SamplePopup()
            {
                Size = new Size(WidthSlider.Value, HeightSlider.Value)
            };

            ConfigureDialogPosition(popup);
            DependencyService.Get<IPopupService>().ShowPopup(popup);
        }

        void ConfigureDialogPosition(Popup popup)
        {
            if ((string)PositionPicker.SelectedItem == "Center")
            {
                popup.HorizontalOptions = LayoutOptions.CenterAndExpand;
                popup.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "Top")
            {
                popup.HorizontalOptions = LayoutOptions.CenterAndExpand;
                popup.VerticalOptions = LayoutOptions.StartAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "TopRight")
            {
                popup.HorizontalOptions = LayoutOptions.EndAndExpand;
                popup.VerticalOptions = LayoutOptions.StartAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "Right")
            {
                popup.HorizontalOptions = LayoutOptions.EndAndExpand;
                popup.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "BottomRight")
            {
                popup.HorizontalOptions = LayoutOptions.EndAndExpand;
                popup.VerticalOptions = LayoutOptions.EndAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "Bottom")
            {
                popup.HorizontalOptions = LayoutOptions.CenterAndExpand;
                popup.VerticalOptions = LayoutOptions.EndAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "BottomLeft")
            {
                popup.HorizontalOptions = LayoutOptions.StartAndExpand;
                popup.VerticalOptions = LayoutOptions.EndAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "Left")
            {
                popup.HorizontalOptions = LayoutOptions.StartAndExpand;
                popup.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
            else if ((string)PositionPicker.SelectedItem == "TopLeft")
            {
                popup.HorizontalOptions = LayoutOptions.StartAndExpand;
                popup.VerticalOptions = LayoutOptions.StartAndExpand;
            }
        }
    }
}