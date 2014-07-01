using System;
using System.ComponentModel;

namespace RSSFeeds
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
        }

        private bool showProgressBar;
        public bool ShowProgressBar
        {
            get { return showProgressBar; }
            set
            {
                if (showProgressBar == value)
                    return;
                showProgressBar = value;
                RaisePropertyChanged("ShowProgressBar");
            }
        }
    }
}
