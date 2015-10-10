using Microsoft.Practices.Unity;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Configuration;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Events;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.Shell.ViewModels
{
    public class MainWindowViewModel : VersatileMediaManagerViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel()
        {
            // Load application config
            this.LoadApplicationConfigFile();

            // Register to events
            this.EventAggregator.GetEvent<UpdateStatusBarMessageEvent>().Subscribe(this.UpdateStatusBarMessageEventHandler);
        }

        #region Event-Handler

        /// <summary>
        /// Update status bar message event handler
        /// </summary>
        /// <param name="statusBarMessage">The status bar message</param>
        private void UpdateStatusBarMessageEventHandler(string statusBarMessage)
        {
            this.StatusBarMessage = statusBarMessage;
        }

        #endregion Event-Handler

        /// <summary>
        /// Load configuration file
        /// </summary>
        /// <returns></returns>
        private IConfigurationFile LoadApplicationConfigFile()
        {
            // Create config file
            IConfigurationFile configFile = new XmlConfigurationFile(FileAndFolderConstants.ApplicationConfigFile);

            if (!configFile.Load())
            {
                // Add section GeneralSettings
                configFile.Sections.Add("GeneralSettings");
                this.CheckGeneralSettings(configFile);
            }
            else
            {
                // Check general settings
                this.CheckGeneralSettings(configFile);
            }

            // Save config file
            configFile.Save();

            // Register global application file
            this.UnityContainer.RegisterInstance<IConfigurationFile>(FileAndFolderConstants.ApplicationConfigFile, configFile);

            return configFile;
        }

        /// <summary>
        /// Check general settings
        /// </summary>
        /// <param name="configFile"></param>
        private void CheckGeneralSettings(IConfigurationFile configFile)
        {
            // Check if section exists
            if (configFile.Sections["GeneralSettings"] == null)
                configFile.Sections.Add("GeneralSettings");

            // Check settings
            if (configFile.Sections["GeneralSettings"].Settings["Theme"] == null)
                configFile.Sections["GeneralSettings"].Settings.Add("Theme", "BaseLight", "BaseLight", typeof(System.String));
            if (configFile.Sections["GeneralSettings"].Settings["Language"] == null)
                configFile.Sections["GeneralSettings"].Settings.Add("Language", "de", "de", typeof(System.String));
            if (configFile.Sections["GeneralSettings"].Settings["AccentColor"] == null)
                configFile.Sections["GeneralSettings"].Settings.Add("AccentColor", "Cyan", "Cyan", typeof(System.String));
        }

        #region Properties

        private string statusBarMessage;

        /// <summary>
        /// Status bar message
        /// </summary>
        public string StatusBarMessage
        {
            get { return statusBarMessage; }
            set { this.SetProperty<string>(ref this.statusBarMessage, value); }
        }

        #endregion Properties
    }
}