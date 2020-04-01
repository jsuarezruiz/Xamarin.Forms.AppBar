using System;

namespace Xamarin.Forms.AppBar
{
	public abstract class BasePopup : View
	{
		protected internal BasePopup()
		{
			Color = Color.White;
			VerticalOptions = LayoutOptions.CenterAndExpand;
			HorizontalOptions = LayoutOptions.CenterAndExpand;
		}

		public virtual View View { get; set; }

		public static readonly BindableProperty ColorProperty =
		   BindableProperty.Create(nameof(Color), typeof(Color), typeof(BasePopup), Color.Default);

		public Color Color
		{
			get => (Color)GetValue(ColorProperty);
			set => SetValue(ColorProperty, value);
		}

		public static readonly BindableProperty AnchorProperty =
            BindableProperty.Create(nameof(Anchor), typeof(View), typeof(BasePopup), null);

		public View Anchor
		{
			get => (View)GetValue(AnchorProperty);
			set => SetValue(AnchorProperty, value);
		}

		public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(Size), typeof(BasePopup), Size.Zero);

		public Size Size
		{
			get => (Size)GetValue(SizeProperty);
			set => SetValue(SizeProperty, value);
		}
        
		public bool IsLightDismissEnabled { get; set; }

		public event EventHandler<PopupDismissedEventArgs> Dismissed;

		protected virtual void OnDismissed(object result)
		{
			Dismissed?.Invoke(this, new PopupDismissedEventArgs { Result = result });
		}

		public virtual void LightDismiss()
		{
			// Empty default implementation
		}
	}
}