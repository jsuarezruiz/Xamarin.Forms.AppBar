using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace AppBar.Sample.Views
{
    public partial class AddRemoveToolBarItemsGallery : ContentPage
    {
        public AddRemoveToolBarItemsGallery()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnAddPrimaryToolBarItemClicked(object sender, EventArgs e)
        {
            var toolBarItemIndex = ToolbarItems.Count + 1;

            var toolbarItem = new ToolbarItem($"Item {toolBarItemIndex}", GetRandomIcon(), OnToolbarClicked);

            ToolbarItems.Add(toolbarItem);
        }

        void OnRemovePrimaryToolBarItemClicked(object sender, EventArgs e)
        {
            var primaryToolbarItems = ToolbarItems.Where(i => i.Order != ToolbarItemOrder.Secondary).ToList();

            if (primaryToolbarItems.Count == 0)
                return;

            var toolBarItemIndex = primaryToolbarItems.Count - 1;
            var toolbarItem = primaryToolbarItems[toolBarItemIndex];

            ToolbarItems.Remove(toolbarItem);
        }

        void OnAddSecondaryToolBarItemClicked(object sender, EventArgs e)
        {
            var toolBarItemIndex = ToolbarItems.Count + 1;

            var toolbarItem = new ToolbarItem($"Item {toolBarItemIndex}", GetRandomIcon(), OnToolbarClicked)
            {
                Order = ToolbarItemOrder.Secondary
            };

            ToolbarItems.Add(toolbarItem);
        }

        void OnRemoveSecondaryToolBarItemClicked(object sender, EventArgs e)
        {
            var secondaryToolbarItems = ToolbarItems.Where(i => i.Order == ToolbarItemOrder.Secondary).ToList();

            if (secondaryToolbarItems.Count == 0)
                return;

            var toolBarItemIndex = secondaryToolbarItems.Count - 1;
            var toolbarItem = secondaryToolbarItems[toolBarItemIndex];

            ToolbarItems.Remove(toolbarItem);
        }

        void OnToolbarClicked()
        {
            Console.WriteLine("OnToolbarClicked");
        }

        string GetRandomIcon()
        {
            var random = new Random();
            var icons = new List<string> { "heart.png", "search.png", "" };
            int index = random.Next(icons.Count);
            return icons[index];
        }
    }
}