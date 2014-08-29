using System;
using log4net.Core;

namespace Logging.Appender
{
    public class MessageLoggedEventArgs : EventArgs
    {
        private LoggingEvent _loggingEvent;

        private String _renderedLoggingEvent;

        public MessageLoggedEventArgs(LoggingEvent loggingEvent, String renderedLoggingEvent)
        {
            _loggingEvent = loggingEvent;
            _renderedLoggingEvent = renderedLoggingEvent;
        }
        public LoggingEvent LoggingEvent
        {
            get { return _loggingEvent; }
        }

        public String RenderedLoggingEvent
        {
            get { return _renderedLoggingEvent; }
        }
    }
}
