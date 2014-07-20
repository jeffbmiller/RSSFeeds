using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RSSFeeds
{	
	public partial class RssFeedView : ContentPage
	{	
		public RssFeedView ()
		{
			InitializeComponent ();
            BindingContext = new RssFeedViewModel();

		}

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as RssRecordViewModel;
            if (item == null)
                return;
            Navigation.PushAsync(new RssWebView(item));
            rsslist.SelectedItem = null;
        }

        private RssFeedViewModel ViewModel { get { return BindingContext as RssFeedViewModel; } }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.Records.Count == 0)
                ViewModel.OnReload();
        }
	}
}

