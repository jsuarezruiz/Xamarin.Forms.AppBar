using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.Forms
{
    public class AppBar : ContentView
    {
        Dictionary<ToolbarItem, AppBarItem> _primaryToolbarItems;
        Dictionary<ToolbarItem, AppBarItem> _secondaryToolbarItems;

        // TODO: Review Layout. Probably we can reduce the hierarchy.
        Page _currentPage;
        Grid _mainContainer;
        RowDefinition _mainContainerRow;
        Grid _backgroundContainer;
        Image _backgroundImage;
        Grid _contentContainer;
        Grid _titleViewContainer;
        Grid _backContainer;
        Image _navigationIcon;
        Label _navigationLabel;
        StackLayout _leftItemsContainer;
        StackLayout _rightItemsContainer;
        Image _rightItemsIcon;
        Label _titleLabel;
        BoxView _barBorder;
        ScrollView _scrollChild;

        public AppBar()
        {
            Initialize();
        }

        // TODO: Include HasShadow, PopupBackgroundColor, etc. properties.

        public static readonly BindableProperty BarHeightProperty =
          BindableProperty.Create(nameof(BarHeight), typeof(double), typeof(AppBar), AppBarSizes.GetDefaultBarHeight(),
              propertyChanged: OnBarHeightChanged);

        public double BarHeight
        {
            get => (double)GetValue(BarHeightProperty);
            set => SetValue(BarHeightProperty, value);
        }

        static void OnBarHeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBarHeight((double)newValue);
        }

        public static readonly BindableProperty BarBackgroundColorProperty =
            BindableProperty.Create(nameof(BarBackgroundColor), typeof(Color), typeof(AppBar), Color.Default,
                propertyChanged: OnBarBackgroundColorChanged);

        public Color BarBackgroundColor
        {
            get => (Color)GetValue(BarBackgroundColorProperty);
            set => SetValue(BarBackgroundColorProperty, value);
        }

        static void OnBarBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBarBackgroundColor((Color)newValue);
        }

        public static readonly BindableProperty BarBackgroundImageProperty =
           BindableProperty.Create(nameof(BarBackgroundImage), typeof(ImageSource), typeof(AppBar), null,
               propertyChanged: OnBarBackgroundImageChanged);

        public ImageSource BarBackgroundImage
        {
            get => (ImageSource)GetValue(BarBackgroundImageProperty);
            set => SetValue(BarBackgroundImageProperty, value);
        }

        static void OnBarBackgroundImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBarBackgroundImage((ImageSource)newValue);
        }

        public static readonly BindableProperty BarBackgroundViewProperty =
           BindableProperty.Create(nameof(BarBackgroundView), typeof(View), typeof(AppBar), null,
               propertyChanged: OnBarBackgroundViewChanged);

        public View BarBackgroundView
        {
            get => (View)GetValue(BarBackgroundViewProperty);
            set => SetValue(BarBackgroundViewProperty, value);
        }

        static void OnBarBackgroundViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBarBackgroundView((View)newValue);
        }

        public static readonly BindableProperty BarTextColorProperty =
           BindableProperty.Create(nameof(BarTextColor), typeof(Color), typeof(AppBar), Color.Default,
               propertyChanged: OnBarTextColorChanged);

        public Color BarTextColor
        {
            get => (Color)GetValue(BarTextColorProperty);
            set => SetValue(BarTextColorProperty, value);
        }

        static void OnBarTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBarTextColor((Color)newValue);
        }

        public static readonly BindableProperty NavigationIconProperty =
         BindableProperty.Create(nameof(NavigationIcon), typeof(ImageSource), typeof(AppBar), null,
             propertyChanged: OnNavigationIconChanged);

        public ImageSource NavigationIcon
        {
            get => (ImageSource)GetValue(NavigationIconProperty);
            set => SetValue(NavigationIconProperty, value);
        }

        static void OnNavigationIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateNavigationIcon((ImageSource)newValue);
        }

        public static readonly BindableProperty BackButtonTitleProperty =
        BindableProperty.Create(nameof(BackButtonTitle), typeof(string), typeof(AppBar), AppBarSizes.GetDefaultBackButtonTitle(),
            propertyChanged: OnBackButtonTitleChanged);

        public string BackButtonTitle
        {
            get => (string)GetValue(BackButtonTitleProperty);
            set => SetValue(BackButtonTitleProperty, value);
        }

        static void OnBackButtonTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBackButtonTitle((string)newValue);
        }

        public static readonly BindableProperty BorderColorProperty =
         BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(AppBar), AppBarSizes.GetDefaultBorderColor(),
             propertyChanged: OnBorderColorChanged);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        static void OnBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBorderColor((Color)newValue);
        }

        public static readonly BindableProperty BorderHeightProperty =
        BindableProperty.Create(nameof(BorderHeight), typeof(double), typeof(AppBar), 0.5d,
            propertyChanged: OnBorderHeightChanged);

        public double BorderHeight
        {
            get => (double)GetValue(BorderHeightProperty);
            set => SetValue(BorderHeightProperty, value);
        }

        static void OnBorderHeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateBorderHeight((int)newValue);
        }

        public static readonly BindableProperty TitleProperty =
          BindableProperty.Create(nameof(Title), typeof(string), typeof(AppBar), string.Empty,
              propertyChanged: OnTitleChanged);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateTitle((string)newValue);
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(AppBar), AppBarSizes.GetDefaultFontFamly());

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(AppBar), FontAttributes.Bold);

        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(AppBar), AppBarSizes.GetDefaultFontSize());

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty TitleViewProperty =
            BindableProperty.Create(nameof(TitleView), typeof(View), typeof(AppBar), null,
                propertyChanged: OnTitleViewChanged);

        public View TitleView
        {
            get => (View)GetValue(TitleViewProperty);
            set => SetValue(TitleViewProperty, value);
        }

        static void OnTitleViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateTitleView((View)newValue);
        }

        public static readonly BindableProperty BackCommandProperty =
           BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(AppBar), null);

        public ICommand BackCommand
        {
            get => (ICommand)GetValue(BackCommandProperty);
            set { SetValue(BackCommandProperty, value); }
        }

        public static readonly BindableProperty BackCommandParameterProperty =
           BindableProperty.Create(nameof(BackCommandParameter), typeof(object), typeof(AppBar), null);

        public object BackCommandParameter
        {
            get => GetValue(BackCommandParameterProperty);
            set { SetValue(BackCommandParameterProperty, value); }
        }

        public static readonly BindableProperty ScrollBehaviorProperty =
         BindableProperty.Create(nameof(ScrollBehavior), typeof(ScrollBehavior), typeof(AppBar), ScrollBehavior.None,
             propertyChanged: OnScrollBehaviorChanged);

        public ScrollBehavior ScrollBehavior
        {
            get => (ScrollBehavior)GetValue(ScrollBehaviorProperty);
            set => SetValue(ScrollBehaviorProperty, value);
        }

        static void OnScrollBehaviorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppBar)bindable).UpdateScrollBehavior((ScrollBehavior)newValue);
        }

        public delegate void BackTappedEventHandler(object sender, EventArgs e);

        public event BackTappedEventHandler BackTapped;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == "Renderer")
                UpdateCurrentPage();
            else if (propertyName == FlowDirectionProperty.PropertyName)
                UpdateFlowDirection();
        }

        void Initialize()
        {
            _primaryToolbarItems = new Dictionary<ToolbarItem, AppBarItem>();
            _secondaryToolbarItems = new Dictionary<ToolbarItem, AppBarItem>();

            _mainContainer = new Grid
            {
                HeightRequest = BarHeight + BorderHeight,
                RowSpacing = 0
            };

            _mainContainerRow = new RowDefinition { Height = GridLength.Auto };
            _mainContainer.RowDefinitions.Add(_mainContainerRow);
            _mainContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            _backgroundContainer = new Grid
            {
                BackgroundColor = BarBackgroundColor
            };

            _backgroundImage = new Image
            {
                Aspect = Aspect.AspectFill
            };

            _backgroundContainer.Children.Add(_backgroundImage);

            _contentContainer = new Grid
            {
                ColumnSpacing = 0,
                HeightRequest = BarHeight,
                VerticalOptions = LayoutOptions.Start
            };

            _contentContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            _contentContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            _contentContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            _contentContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            _titleViewContainer = new Grid
            {
                InputTransparent = true
            };

            _backContainer = new Grid
            {
                ColumnSpacing = 0
            };

            _backContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            _backContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var backGlyph = new FontImageSource
            {
                Color = BarTextColor,
                Glyph = AppBarSizes.GetNavigationGlyph(),
                Size = AppBarSizes.GetNavigationFontSize(),
                FontFamily = AppBarSizes.GetNavigationFontFamily()
            };

            _navigationIcon = new Image
            {
                Source = backGlyph,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Margin = AppBarSizes.GetNavigationIconMargin()
            };

            var backTapGestureRecognizer = new TapGestureRecognizer();
            backTapGestureRecognizer.Tapped += OnBackTapped;
            _backContainer.GestureRecognizers.Add(backTapGestureRecognizer);

            _backContainer.Children.Add(_navigationIcon);
            Grid.SetColumn(_navigationIcon, 0);

            _navigationLabel = new Label
            {
                Text = BackButtonTitle,
                TextColor = BarTextColor,
                FontSize = 17,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(-12, 0, 0, 0)
            };

            _backContainer.Children.Add(_navigationLabel);
            Grid.SetColumn(_navigationLabel, 1);

            _leftItemsContainer = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            _titleLabel = new Label
            {
                Text = Title,
                TextColor = BarTextColor,
                FontFamily = FontFamily,
                FontAttributes = FontAttributes,
                FontSize = FontSize,
                LineBreakMode = LineBreakMode.TailTruncation,
                HorizontalOptions = AppBarSizes.GetTitleLayoutOptions(),
                VerticalOptions = LayoutOptions.Center,
                Margin = AppBarSizes.GetTitleMargin()
            };

            var rightItemsContent = new Grid
            {
                ColumnSpacing = 0
            };

            rightItemsContent.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            var rightItemsIconRow = new ColumnDefinition { Width = GridLength.Auto };
            rightItemsContent.ColumnDefinitions.Add(rightItemsIconRow);

            _rightItemsContainer = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var rightItemsGlyph = new FontImageSource
            {
                Color = BarTextColor,
                Glyph = AppBarSizes.GetRightItemsGlyph(),
                Size = AppBarSizes.GetNavigationFontSize(),
                FontFamily = AppBarSizes.GetNavigationFontFamily()
            };

            _rightItemsIcon = new Image
            {
                Source = rightItemsGlyph,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                IsVisible = false,
                Margin = new Thickness(6, 0, 12, 0)
            };

            var rightItemsTapGestureRecognizer = new TapGestureRecognizer();
            rightItemsTapGestureRecognizer.Tapped += OnRightItemsTapped;
            _rightItemsIcon.GestureRecognizers.Add(rightItemsTapGestureRecognizer);

            rightItemsContent.Children.Add(_rightItemsContainer);
            rightItemsContent.Children.Add(_rightItemsIcon);

            Grid.SetColumn(_rightItemsContainer, 0);
            Grid.SetColumn(_rightItemsIcon, 1);
            
            _barBorder = new BoxView
            {
                Color = BorderColor,
                HeightRequest = BorderHeight,
                Opacity = 0.5
            };

            _contentContainer.Children.Add(_backContainer);
            _contentContainer.Children.Add(_leftItemsContainer);
            _contentContainer.Children.Add(_titleLabel);
            _contentContainer.Children.Add(rightItemsContent);

            Grid.SetColumn(_backContainer, 0);
            Grid.SetColumn(_leftItemsContainer, 1);
            Grid.SetColumn(_titleLabel, 2);
            Grid.SetColumn(rightItemsContent, 3);

            _mainContainer.Children.Add(_backgroundContainer);
            _mainContainer.Children.Add(_contentContainer);
            _mainContainer.Children.Add(_titleViewContainer);

            _mainContainer.Children.Add(_barBorder);
            Grid.SetRow(_barBorder, 1);

            Content = _mainContainer;

            UpdateFlowDirection();
        }

        void UpdateCurrentPage()
        {
            NavigationPage navigationPage = null;
            var currentPage = Application.Current.MainPage;

            if (currentPage is NavigationPage navPage)
            {
                navigationPage = navPage;
                _currentPage = navigationPage.CurrentPage;
            }
            else if (currentPage is MasterDetailPage masterDetailPage)
                _currentPage = masterDetailPage.Detail;
            else
                _currentPage = currentPage;

            if (navigationPage != null)
            {
                if (BarBackgroundColor == Color.Default)
                {
                    BarBackgroundColor = navigationPage.BarBackgroundColor;
                    UpdateBarBackgroundColor(navigationPage.BarBackgroundColor);
                }

                if (BarTextColor == Color.Default)
                {
                    BarTextColor = navigationPage.BarTextColor;
                    UpdateBarTextColor(navigationPage.BarTextColor);
                }
            }

            if (_currentPage != null)
            {
                // TODO: Unsubscribe Page events
                _currentPage.SizeChanged += OnCurrentPageSizeChanged;
                _currentPage.PropertyChanged += OnCurrentPagePropertyChanged;
                ((ObservableCollection<ToolbarItem>)_currentPage.ToolbarItems).CollectionChanged += OnToolbarItemsChanged;

                UpdateTitle(_currentPage.Title);
                UpdatePrimaryToolbarItems(_currentPage.ToolbarItems);
                UpdateSecondaryToolbarItems(_currentPage.ToolbarItems);
                UpdateScrollChild(_currentPage);
            }
        }

        void UpdateFlowDirection()
        {
            // TODO: Manage FlowDirection changes.
        }

        void OnCurrentPageSizeChanged(object sender, EventArgs e)
        {
            var page = (Page)sender;
            var pageWidth = page.Width;

            var navigationWidth = _navigationIcon.Width + _navigationLabel.Width;
            var titleWidth = _titleLabel.Width;
            var leftItemsWidth = _leftItemsContainer.Width;
            var righItemsWidth = _rightItemsContainer.Width;

            var navContentWidth = navigationWidth + titleWidth + leftItemsWidth + righItemsWidth;

            // Update BackButtonTitle Visibility
            _navigationLabel.IsVisible = pageWidth - navContentWidth >= 60;

            // TODO: Update the AppBar sizes based on the Orientation.
        }

        void OnCurrentPagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var page = (Page)sender;

            if (e.PropertyName == Page.TitleProperty.PropertyName)
                UpdateTitle(page.Title);
            else if (e.PropertyName == "SafeAreaInsets")
                UpdateSafeAreaInsets(page);
        }

        void OnToolbarItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // TODO: Avoid redoing the entire collection again!
            UpdatePrimaryToolbarItems(_currentPage.ToolbarItems);
            UpdateSecondaryToolbarItems(_currentPage.ToolbarItems);
        }

        void UpdateBarHeight(double barHeight)
        {
            _mainContainer.HeightRequest = barHeight + BorderHeight;
            _mainContainerRow.Height = barHeight;
            UpdateSafeAreaInsets(_currentPage);
        }

        void UpdateBarBackgroundColor(Color barBackgroundColor)
        {
            _backgroundContainer.BackgroundColor = barBackgroundColor;
        }

        void UpdateBarBackgroundImage(ImageSource barBackgroundImage)
        {
            _backgroundImage.Source = barBackgroundImage;
            _backgroundImage.IsAnimationPlaying = true;
        }

        void UpdateBarBackgroundView(View barBackgroundView)
        {
            if (barBackgroundView != null)
                _backgroundContainer.Children.Add(barBackgroundView);
            else
            {
                _backgroundContainer.Children.Clear();
                _backgroundContainer.Children.Add(_backgroundImage);
            }
        }

        void UpdateBarTextColor(Color barTextColor)
        {
            _navigationLabel.TextColor = barTextColor;
            _titleLabel.TextColor = barTextColor;

            foreach (var toolbarItem in _primaryToolbarItems)
            {
                if (toolbarItem.Value is AppBarItem appBarItem)
                    appBarItem.TextColor = barTextColor;
            }

            foreach (var toolbarItem in _secondaryToolbarItems)
            {
                if (toolbarItem.Value is AppBarItem appBarItem)
                    appBarItem.TextColor = barTextColor;
            }
        }

        void UpdateNavigationIcon(ImageSource navigationIcon)
        {
            _backgroundImage.Source = navigationIcon;
        }

        void UpdateBackButtonTitle(string backButtonTitle)
        {
            _navigationLabel.Text = backButtonTitle;
        }

        void UpdateBorderColor(Color borderColor)
        {
            _barBorder.Color = borderColor;
        }

        void UpdateBorderHeight(double borderHeight)
        {
            _barBorder.HeightRequest = borderHeight;
        }

        void UpdateTitleView(View titleView)
        {
            if (titleView != null)
                _titleViewContainer.Children.Add(titleView);
            else
                _titleViewContainer.Children.Clear();
        }

        void UpdateTitle(string title)
        {
            _titleLabel.Text = title;
        }

        void UpdateSafeAreaInsets(Page page)
        {
            if (page == null)
                return;

            var safeAreaInsets = page.On<iOS>().SafeAreaInsets();
            var topSafeAreaInset = safeAreaInsets.Top;

            _mainContainer.HeightRequest += topSafeAreaInset;
            _contentContainer.Margin = new Thickness(0, topSafeAreaInset, 0, 0);

            if (_titleViewContainer.Children.Count > 0)
            {
                var titleView = _titleViewContainer.Children[0];
                var previousMargin = titleView.Margin;
                titleView.Margin = new Thickness(previousMargin.Left, previousMargin.Top + topSafeAreaInset, previousMargin.Right, previousMargin.Bottom);
            }
        }

        void UpdateScrollChild(Page page)
        {
            var result = page.GetChildrenOfType<ScrollView>();

            foreach (var scroll in result)
            {
                if (scroll.Y == 0)
                {
                    _scrollChild = scroll;
                    break;
                }
            }

            if (_scrollChild != null)
                UpdateScrollBehavior(ScrollBehavior);
        }

        void UpdateScrollBehavior(ScrollBehavior scrollBehavior)
        {
            // TODO: Complete and Improve ScrollBehavior logic (Experimental)
            if (scrollBehavior == ScrollBehavior.None)
            {
                if (_scrollChild != null)
                    _scrollChild.Scrolled -= OnScrollChildScrolled;
            }

            if (scrollBehavior == ScrollBehavior.AutoHide)
            {
                if (_scrollChild != null)
                    _scrollChild.Scrolled += OnScrollChildScrolled;
            }
        }

        void OnScrollChildScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollY = e.ScrollY;

            // TODO: Improve ScrollBehavior visual effect.
            if (scrollY >= BarHeight / 2)
                this.TranslateTo(0, 0 - BarHeight, 250, Easing.CubicOut);
            else
                this.TranslateTo(0, 0, 50, Easing.CubicIn);
        }

        void UpdatePrimaryToolbarItems(IList<ToolbarItem> toolBarItems)
        {
            ClearPrimaryToolBarItems();

            // TODO: Avoid using Linq here
            foreach (var toolBarItem in toolBarItems.OrderBy(tbi => tbi.Priority))
            {
                if (toolBarItem.Order == ToolbarItemOrder.Default || toolBarItem.Order == ToolbarItemOrder.Primary)
                {
                    toolBarItem.PropertyChanged += OnToolBarItemPropertyChanged;

                    AddPrimaryToolBarItem(toolBarItem);
                }
            }
        }

        void UpdateSecondaryToolbarItems(IList<ToolbarItem> toolBarItems)
        {
            ClearSecondaryToolBarItems();

            int rightItemsCount = 0;

            // TODO: Avoid using Linq here
            foreach (var toolBarItem in toolBarItems.OrderBy(tbi => tbi.Priority))
            {
                if (toolBarItem.Order == ToolbarItemOrder.Secondary)
                {
                    toolBarItem.PropertyChanged += OnToolBarItemPropertyChanged;

                    AddSecondaryToolBarItem(toolBarItem);

                    rightItemsCount++;
                }
            }

            if (Device.RuntimePlatform == Device.Android)
                _rightItemsIcon.IsVisible = rightItemsCount > 0;
        }

        void ClearPrimaryToolBarItems()
        {
            foreach (var toolbarItem in _primaryToolbarItems)
                toolbarItem.Key.PropertyChanged -= OnToolBarItemPropertyChanged;

            _primaryToolbarItems.Clear();
            _leftItemsContainer.Children.Clear();
            _rightItemsContainer.Children.Clear();
        }

        void ClearSecondaryToolBarItems()
        {
            foreach (var toolbarItem in _secondaryToolbarItems)
                toolbarItem.Key.PropertyChanged -= OnToolBarItemPropertyChanged;

            _secondaryToolbarItems.Clear();
        }

        void AddPrimaryToolBarItem(ToolbarItem item)
        {
            var primaryToolBarItem = new AppBarItem
            {
                AutomationId = item.AutomationId,
                IconImageSource = item.IconImageSource,
                Text = item.Text,
                TextColor = BarTextColor,
                Order = item.Order,
                Command = item.Command,
                CommandParameter = item.CommandParameter,
                ToolbarItem = item
            };

            _rightItemsContainer.Children.Add(primaryToolBarItem);
            _primaryToolbarItems.Add(item, primaryToolBarItem);
        }

        void AddSecondaryToolBarItem(ToolbarItem item)
        {
            var secondaryToolBarItem = new AppBarItem
            {
                AutomationId = item.AutomationId,
                Text = item.Text,
                TextColor = BarTextColor,
                Order = item.Order,
                Command = item.Command,
                CommandParameter = item.CommandParameter,
                ToolbarItem = item
            };

            _secondaryToolbarItems.Add(item, secondaryToolBarItem);
        }

        void OnToolBarItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var toolBarItem = (ToolbarItem)sender;

            if (e.PropertyName == MenuItem.TextProperty.PropertyName)
                UpdateToolbarItemText(toolBarItem);
            else if (e.PropertyName == MenuItem.IconImageSourceProperty.PropertyName)
                UpdateToolbarItemIcon(toolBarItem);
            else if (e.PropertyName == MenuItem.IsEnabledProperty.PropertyName)
                UpdateToolbarItemIsEnabled(toolBarItem);
        }

        void UpdateToolbarItemText(ToolbarItem toolBarItem)
        {
            var appBarItem = GetToolBarItem(toolBarItem);

            if (appBarItem != null)
            {
                appBarItem.Text = toolBarItem.Text;
            }
        }

        void UpdateToolbarItemIcon(ToolbarItem toolBarItem)
        {
            var appBarItem = GetToolBarItem(toolBarItem);

            if (appBarItem != null)
            {
                appBarItem.IconImageSource = toolBarItem.IconImageSource;
            }
        }

        void UpdateToolbarItemIsEnabled(ToolbarItem toolBarItem)
        {
            var appBarItem = GetToolBarItem(toolBarItem);

            if (appBarItem != null)
            {
                appBarItem.IsEnabled = toolBarItem.IsEnabled;
            }
        }

        AppBarItem GetToolBarItem(ToolbarItem toolBarItem)
        {
            _primaryToolbarItems.TryGetValue(toolBarItem, out AppBarItem primaryAppBarItem);

            if (primaryAppBarItem != null)
                return primaryAppBarItem;

            _secondaryToolbarItems.TryGetValue(toolBarItem, out AppBarItem secondaryAppBarItem);

            if (secondaryAppBarItem != null)
                return secondaryAppBarItem;

            return null;
        }

        internal virtual void OnBackTapped(EventArgs e)
        {
            BackTappedEventHandler handler = BackTapped;
            handler?.Invoke(this, e);

            if (BackCommand != null)
                BackCommand.Execute(BackCommandParameter);
        }

        void OnBackTapped(object sender, EventArgs e)
        {
            if (_currentPage == null)
                return;

            OnBackTapped(e);

            _currentPage.Navigation.PopAsync();
        }

        void OnRightItemsTapped(object sender, EventArgs e)
        {
            // TODO: Open Popup in Android, secondary bar in iOS, etc.
        }
    }
}