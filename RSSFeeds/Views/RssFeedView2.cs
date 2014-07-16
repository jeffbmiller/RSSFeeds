using System;
using Xamarin.Forms;

namespace RSSFeeds
{
    public class RssFeedView2 : ContentPage
    {
        private RssFeedViewModel viewModel;

        public RssFeedView2()
        {
            this.viewModel = new RssFeedViewModel();
            this.BindingContext = viewModel;
            this.Title = "Rss Feed";

            var refresh = new ToolbarItem(){ Command = viewModel.ReloadCommand, Name = "Reload", Priority = 0 };
            ToolbarItems.Add(refresh);

            var stack = new StackLayout(){ Orientation = StackOrientation.Vertical };
            var activity = new ActivityIndicator(){ Color = Color.Blue, IsEnabled = true };
            activity.SetBinding(ActivityIndicator.IsVisibleProperty, "ShowActivityIndicator");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "ShowActivityIndicator");

            stack.Children.Add(activity);

            var listview = new ListView();
            listview.ItemsSource = viewModel.Records;
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.DetailProperty, "Image");
            listview.ItemTemplate = cell;
            listview.ItemSelected += async (sender, e) => {
                await Navigation.PushAsync(new RssWebView((RssRecordViewModel)e.SelectedItem));
                listview.SelectedItem = null;
            };

            stack.Children.Add(listview);

            Content = stack;
        }
    }
}

