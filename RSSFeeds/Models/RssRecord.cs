using System;
using System.Text.RegularExpressions;

namespace RSSFeeds
{
    public class RssRecord
    {
        public RssRecord(string title, string image, string link)
        {
            this.Title = title;
            var match = Regex.Match(image, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                this.Image = match.Groups[1].Value;
            }          

            this.Link = link;
        }

        public string Title {get;set;}
        public string Link { get; set;}
        public string Image {get;set;}
    }
}

