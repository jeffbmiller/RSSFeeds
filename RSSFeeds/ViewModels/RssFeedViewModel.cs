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
            InitalizeCommands();
        }

        #region Commands

        public Command ReloadCommand { get; private set;}

        private void InitalizeCommands()
        {
            ReloadCommand = new Command(() => OnReload(), () => CanReload());
        }

        private void OnReload()
        {
            records = null;
            RaisePropertyChanged("Records");
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

        private ObservableCollection<RssRecordViewModel> records;
        public ObservableCollection<RssRecordViewModel> Records
        {
            get {
                if (records == null)
                    GetRecords();
                return records;
            }
        }

        #endregion

        private async void GetRecords()
        {
            ShowActivityIndicator = true;
            var result = await GetRecordsAsync();
            records = new ObservableCollection<RssRecordViewModel>(result.Select(x=> new RssRecordViewModel(x)).ToList());
            RaisePropertyChanged("Records");
            ShowActivityIndicator = false;
        }

        private Task<IEnumerable<RssRecord>> GetRecordsAsync()
        {
            return Task.Factory.StartNew(() =>
                {
                    return service.GetRssRecords();
                });
        }

    }
}

