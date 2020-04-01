using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.AppBar.Android;

[assembly: Dependency(typeof(PopupService))]
namespace Xamarin.Forms.AppBar.Android
{
    public class PopupService : IPopupService
    {
        public Task<T> ShowPopup<T>(Popup<T> popup)
        {
            // TODO: Refactor!
            Platform.Android.Platform.CreateRenderer(popup);
            return popup.Result;
        }
    }
}