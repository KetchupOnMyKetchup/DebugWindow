using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;

namespace Logging.Appender
{
    public delegate void MessageLoggedEventHandler(object sender, MessageLoggedEventArgs e);


    /// <summary>
    /// Appender that raises an event for each LoggingEvent received
    /// </summary>
    /// <remarks>
    /// Raises a MessageLoggedEvent for each LoggingEvent object received
    /// by this appender.
    /// </remarks>
    public class FireEventAppender : log4net.Appender.AppenderSkeleton
    {
        private static FireEventAppender m_instance;

        private FixFlags m_fixFlags = FixFlags.All;

        // Event handler
        public event MessageLoggedEventHandler MessageLoggedEvent;

        // Easy singleton, gets the last instance created
        public static FireEventAppender Instance
        {
            get { return m_instance; }
        }

        public FireEventAppender()
        {
            // Store the instance created
            m_instance = this;
        }

        virtual public FixFlags Fix
        {
            get { return m_fixFlags; }
            set { m_fixFlags = value; }
        }

        override protected void Append(LoggingEvent loggingEvent)
        {
            // Because we the LoggingEvent may be used beyond the lifetime 
            // of the Append() method we must fix any volatile data in the event
            loggingEvent.Fix = this.Fix;

            // Raise the event
            MessageLoggedEventHandler handler = MessageLoggedEvent;
            if (handler != null)
            {
                handler(this, new MessageLoggedEventArgs(loggingEvent, RenderLoggingEvent(loggingEvent)));
            }
        }
    }
}
