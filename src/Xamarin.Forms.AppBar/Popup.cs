using System.Threading.Tasks;

namespace Xamarin.Forms.AppBar
{
	// Based on: https://github.com/xamarin/Xamarin.Forms/pull/9616 by Andrew Hoefling
	// TODO: Refactor, rename properties to use PlacementTarget and Placement?
	public abstract class Popup<T> : BasePopup
	{
		TaskCompletionSource<T> _tcs;
		View _view;

		protected Popup()
		{
			_tcs = new TaskCompletionSource<T>();
		}

		public override View View
		{
			get => _view;
			set
			{
				if (_view == value)
					return;

				if (value is IPopupView<T> popupView)
				{
					popupView.SetDismissDelegate(Dismiss);
				}

				_view = value;
			}
		}

		public void Reset()
		{
			_tcs = new TaskCompletionSource<T>();
		}

		public void Dismiss(T result)
		{
			_tcs.TrySetResult(result);
			OnDismissed(result);
		}

		public Task<T> Result => _tcs.Task;

		public override void LightDismiss()
		{
			_tcs.TrySetResult(OnLightDismissed());
		}

		protected virtual T OnLightDismissed()
		{
			return default;
		}
	}

	public class Popup : Popup<object>
	{
		public Popup() { }

		public Popup(View view)
		{
			View = view;
		}
	}
}