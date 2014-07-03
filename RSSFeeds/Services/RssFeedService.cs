using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using Xamarin.Forms;

namespace RSSFeeds
{
    public class RssFeedService
    {
        public IEnumerable<RssRecord> GetRssRecords()
        {
            return XDocument.Load(@"http://www.cbc.ca/cmlink/rss-topstories").Descendants("item").Select(
                               x => new RssRecord(
                                   (string)x.Element("title"),
                    (string)x.Element("description"),
                                    (string)x.Element("link"))).ToList();
        }
    }
}

