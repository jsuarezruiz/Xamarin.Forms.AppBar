using System.ComponentModel;

namespace Xamarin.Forms
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class AppBarSizes
    {
        public static double GetDefaultBarHeight()
        {
            if (Device.RuntimePlatform == Device.Android)
                return 60d;

            if (Device.RuntimePlatform == Device.iOS)
                return 44d;

            return 60d;
        }

        public static string GetDefaultFontFamly()
        {
            if (Device.RuntimePlatform == Device.Android)
                return "Roboto-Medium.ttf#Roboto Medium";

            return string.Empty;
        }

        public static double GetDefaultFontSize()
        {
            if (Device.RuntimePlatform == Device.Android)
                return 20d;

            if (Device.RuntimePlatform == Device.iOS)
                return 17d;

            return 20d;
        }

        public static double GetNavigationFontSize()
        {
            if (Device.RuntimePlatform == Device.Android)
                return 24d;

            if (Device.RuntimePlatform == Device.iOS)
                return 48d;

            return 24d;
        }

        public static string GetNavigationFontFamily()
        {
            if (Device.RuntimePlatform == Device.Android)
                return "materialdesignicons-webfont.ttf#Material Design Icons";

            if (Device.RuntimePlatform == Device.iOS)
                return "Material Design Icons";

            return string.Empty;
        }

        public static string GetNavigationGlyph()
        {
            if (Device.RuntimePlatform == Device.Android)
                return "\uF04D";

            if (Device.RuntimePlatform == Device.iOS)
                return "\uF141";

            return string.Empty;
        }

        public static string GetDefaultBackButtonTitle()
        {
            if (Device.RuntimePlatform == Device.Android)
                return string.Empty;

            if (Device.RuntimePlatform == Device.iOS)
                return "Back";

            return string.Empty;
        }

        public static Color GetDefaultBorderColor()
        {
            if (Device.RuntimePlatform == Device.Android)
                return Color.Default;

            if (Device.RuntimePlatform == Device.iOS)
                return Color.Black;

            return Color.Default;
        }

        public static Thickness GetNavigationIconMargin()
        {
            if (Device.RuntimePlatform == Device.Android)
                return new Thickness(18, 0, 12, 0);

            if (Device.RuntimePlatform == Device.iOS)
                return new Thickness(0);

            return new Thickness(0);
        }

        public static LayoutOptions GetTitleLayoutOptions()
        {
            if (Device.RuntimePlatform == Device.Android)
                return LayoutOptions.Start;

            if (Device.RuntimePlatform == Device.iOS)
                return LayoutOptions.Center;

            return LayoutOptions.Start;
        }

        public static Thickness GetTitleMargin()
        {
            if (Device.RuntimePlatform == Device.Android)
                return new Thickness(18, 0, 6, 0);

            if (Device.RuntimePlatform == Device.iOS)
                return new Thickness(0, 0, 60, 0);

            return new Thickness(0);
        }

        public static double GetToolBarItemSize()
        {
            if (Device.RuntimePlatform == Device.Android)
                return 32d;

            if (Device.RuntimePlatform == Device.iOS)
                return 48d;

            return 48d;
        }
    }
}