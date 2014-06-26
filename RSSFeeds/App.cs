using System;
using Xamarin.Forms;

namespace RSSFeeds
{
    public class App
    {
        public static Page GetMainPage()
        {	
            return new NavigationPage(new RssFeedView());
        }
    }
}

