using System;
using System.Collections.Generic;
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

        void OnAddToolBarItemClicked(object sender, EventArgs e)
        {
            var toolBarItemIndex = ToolbarItems.Count + 1;

            var toolbarItem = new ToolbarItem($"Item {toolBarItemIndex}", GetRandomIcon(), OnToolbarClicked);

            ToolbarItems.Add(toolbarItem);
        }

        void OnRemoveToolBarItemClicked(object sender, EventArgs e)
        {
            if (ToolbarItems.Count == 0)
                return;

            var toolBarItemIndex = ToolbarItems.Count - 1;
            ToolbarItems.RemoveAt(toolBarItemIndex);
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