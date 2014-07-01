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

        private bool showActivityIndicator;
        public bool ShowActivityIndicator
        {
            get { return showActivityIndicator; }
            set
            {
                if (showActivityIndicator == value)
                    return;
                showActivityIndicator = value;
                RaisePropertyChanged("ShowActivityIndicator");
            }
        }
    }
}
