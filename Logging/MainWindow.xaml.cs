using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logging.Appender;
using Logging.ViewModel;

namespace Logging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainWindow));

        /// <summary>
        /// The LoggingEventBuilder is a StringBuilder instance associated with MainWindow.
        /// Whenever a Logging Event occurs (the code hits a log.Info("message") line for example, 
        /// the <code>FireEventAppender</code> will fire an Event that contains the Log Message. 
        /// 
        /// We do need to look into possibly limiting how big this StringBuilder gets.
        /// It will be removed from Memory when the Application is shut down.  However, if someone
        /// has a long-running Session and this keeps growing and growing, it will keep taking
        /// more and more Memory.  
        /// </summary>
        public StringBuilder LoggingEventBuilder { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // Just construct the LoggingEventBuilder in the MainWindow Default Constructor.
            LoggingEventBuilder = new StringBuilder();

            // Wire in the Callback method to the Appender
            FireEventAppender.Instance.MessageLoggedEvent += FireEventHandler;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log.Info("New Debug Window instance opened");

            DebugWindowViewModel newDebugWindowViewModel = new DebugWindowViewModel();
            newDebugWindowViewModel.NotificationMessage = "Bugs bugs bugs.. splat! Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean mauris nisi, lobortis sit amet magna at, sagittis bibendum justo. Proin sed enim eget nisl sollicitudin lobortis. Nam a velit et lacus aliquet tristique. Proin quam sem, placerat ut eros sed, dapibus egestas nibh. Proin eu dictum mauris, non elementum sem. Phasellus ut faucibus felis. Donec condimentum eget velit sed ultrices. Duis mi risus, accumsan id ultrices ut, ultrices molestie augue. In iaculis dui erat. Nunc vel quam malesuada, consequat dolor non, consectetur ex. Fusce vehicula mollis tellus, pellentesque interdum magna fringilla sit amet. Aliquam venenatis, metus vel imperdiet aliquam, dolor lectus mollis lorem, at tincidunt libero nisi ac mi. Duis eros augue, porta in vehicula vitae, volutpat a augue..";

            DebugWindow newDebugWindow = new DebugWindow();
            newDebugWindow.Owner = this;
            newDebugWindow.DataContext = newDebugWindowViewModel;
            newDebugWindow.Show();
        }

        /// <summary>
        /// Callback method that matches the delegate signature <code>MessageLoggedEventHandler</code>.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The MessageLogged Event Arguments</param>
        private void FireEventHandler(object sender, MessageLoggedEventArgs e)
        {
            MessageBox.Show(e.RenderedLoggingEvent);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            log.Info("Here is a Message");

        }
    }
}
