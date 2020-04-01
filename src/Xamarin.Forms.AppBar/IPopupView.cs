using System;

namespace Xamarin.Forms.AppBar
{
    public interface IPopupView<out T> : IPopup
    {
        void SetDismissDelegate(Action<T> dismissDelegate);
    }
}