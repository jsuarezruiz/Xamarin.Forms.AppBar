using Xamarin.Forms.AppBar;

namespace AppBar.Sample.Views
{
    public partial class SamplePopup : Popup
    {
        public SamplePopup()
        {
            InitializeComponent();
        }

        void OnDimissClicked(object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}