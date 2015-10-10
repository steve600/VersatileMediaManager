using System;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Shell.Events;

namespace VersatileMediaManager.Shell.ViewModels
{
    public class SplashScreenViewModel : VersatileMediaManagerViewModelBase
    {
        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        public SplashScreenViewModel()
        {
            string appVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            this.ApplicationDisplayString = String.Format("v{0}", appVersion);

            this.EventAggregator.GetEvent<SplashScreenStatusMessageUpdateEvent>().Subscribe(UpdateMessage);
        }

        #endregion CTOR

        #region Properties

        private string applicationDisplayString;

        /// <summary>
        /// Application display string
        /// </summary>
        public string ApplicationDisplayString
        {
            get { return applicationDisplayString; }
            set { this.SetProperty<string>(ref this.applicationDisplayString, value); }
        }

        private string splashScreenStatusMessage = string.Empty;

        /// <summary>
        /// Status message
        /// </summary>
        public string SplashScreenStatusMessage
        {
            get { return splashScreenStatusMessage; }
            set { this.SetProperty<string>(ref this.splashScreenStatusMessage, value); }
        }

        #endregion Properties

        #region Private Methods

        private void UpdateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            this.SplashScreenStatusMessage += string.Concat(Environment.NewLine, message, "...");
        }

        #endregion Private Methods
    }
}