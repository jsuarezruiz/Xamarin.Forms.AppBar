using System.Threading.Tasks;

namespace Xamarin.Forms.AppBar
{
    public interface IPopupService
    {
        Task<T> ShowPopup<T>(Popup<T> popup);
    }
}
