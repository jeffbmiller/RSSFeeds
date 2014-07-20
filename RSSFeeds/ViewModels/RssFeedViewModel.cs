using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace RSSFeeds
{
    public class RssFeedViewModel : BaseViewModel
    {
        private readonly RssFeedService service;

        public RssFeedViewModel()
        {
            this.service = new RssFeedService();
            Records = new ObservableCollection<RssRecordViewModel>();
            InitalizeCommands();
        }

        #region Commands

        public Command ReloadCommand { get; private set;}

        private void InitalizeCommands()
        {
            ReloadCommand = new Command(() => OnReload(), () => CanReload());
        }

        public async void OnReload()
        {
            Records.Clear();
            ShowActivityIndicator = true;
            var records = await GetRecordsAsync();
            foreach (var record in records)
                Records.Add(new RssRecordViewModel(record));
 
            RaisePropertyChanged("Records");
            ShowActivityIndicator = false;
        }

        public bool CanReload()
        {
            return !ShowActivityIndicator;
        }

        #endregion

        #region Properties

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
          
        public ObservableCollection<RssRecordViewModel> Records { get; set; }
        #endregion

        private Task<IEnumerable<RssRecord>> GetRecordsAsync()
        {
            return Task.Factory.StartNew(() =>
                {
                    return service.GetRssRecords();
                });
        }

    }
}

