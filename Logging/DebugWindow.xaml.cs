using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using log4net;
using log4net.Core;


namespace Logging
{
    /// <summary>
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow 
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DebugWindow));

        public DebugWindow()
        {
            log.Info("Creating DebugWindow Instance");
            InitializeComponent();

     
        }


    }
}
