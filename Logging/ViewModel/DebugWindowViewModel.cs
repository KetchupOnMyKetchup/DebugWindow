using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.ViewModel
{
    class DebugWindowViewModel : ObservableViewModel
    {
        /// <summary>
        /// Private field for the Notification Title.
        /// </summary>
        private String _notificationMessage = "";

        /// <summary>
        /// Property for the Notification Title.
        /// </summary>
        public string NotificationMessage
        {
            get { return _notificationMessage; }
            set
            {
                _notificationMessage = value;
                RaisePropertyChangedEvent("NotificationMessage");
            }
        }
    }
}
