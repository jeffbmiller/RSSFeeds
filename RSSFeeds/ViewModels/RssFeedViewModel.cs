using System;
using System.Collections.Generic;
using System.Linq;

namespace RSSFeeds
{
    public class RssFeedViewModel : BaseViewModel
    {
        private readonly RssFeedService service;

        public RssFeedViewModel()
        {
            this.service = new RssFeedService();
        }

        private RssRecordViewModel selected;
        public RssRecordViewModel Selected
        {
            get { return selected; }
            set {
                if (selected == value)
                    return;
                selected = value;
                RaisePropertyChanged("Selected");
            }
        }

        private IEnumerable<RssRecordViewModel> records;
        public IEnumerable<RssRecordViewModel> Records
        {
            get {
                if (records == null)
                    records = service.GetRssRecords().Select(x => new RssRecordViewModel(x)).ToList();
                return records;
            }
        }
    }
}

