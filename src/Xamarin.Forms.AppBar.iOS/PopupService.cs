using System.Threading.Tasks;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.AppBar.iOS;

[assembly: Dependency(typeof(PopupService))]
namespace Xamarin.Forms.AppBar.iOS
{
    public class PopupService : IPopupService
    {
        UIPopoverPresentationController _popoverPresentationController;

        public async Task<T> ShowPopup<T>(Popup<T> popup)
        {
            var wrapper = PopupWrapper<T>.Wrap(popup);

            var currenPageRenderer = Platform.iOS.Platform.GetRenderer(Application.Current.MainPage);
            var presentingViewController = currenPageRenderer.ViewController;

            var anchorNativeView = popup.Anchor == null ? currenPageRenderer.NativeView : Platform.iOS.Platform.GetRenderer(popup.Anchor).NativeView;

            wrapper.ModalInPopover = !popup.IsLightDismissEnabled;
            wrapper.ModalPresentationStyle = UIModalPresentationStyle.Popover;

            presentingViewController.PresentViewController(wrapper, true, null);

            _popoverPresentationController = wrapper.PopoverPresentationController;

            _popoverPresentationController.DidDismiss += (sender, e) =>
            {
                popup.LightDismiss();
                _popoverPresentationController = null;
            };

            _popoverPresentationController.SourceRect = new CGRect(anchorNativeView.Bounds.Location, anchorNativeView.Bounds.Size);
            _popoverPresentationController.SourceView = anchorNativeView;

            var result = await popup.Result;

            var isiOS9OrNewer = UIDevice.CurrentDevice.CheckSystemVersion(9, 0);

            if (!isiOS9OrNewer)
            {
                await presentingViewController.DismissViewControllerAsync(true);
            }
            else
            {
                presentingViewController.DismissViewController(true, null);
            }

            _popoverPresentationController = null;
            return result;
        }
    }
}
