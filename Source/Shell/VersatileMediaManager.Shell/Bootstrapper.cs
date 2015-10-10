using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using VersatileMediaManager.Infrastructure;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Events;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;
using VersatileMediaManager.Infrastructure.Services;
using VersatileMediaManager.Shell.Events;
using VersatileMediaManager.Shell.Views;

namespace VersatileMediaManager.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        private AutoResetEvent WaitForCreation { get; set; }

        /// <summary>
        /// The shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            Container.RegisterInstance(typeof(Window), GlobalConstants.MainWindowName, Container.Resolve<MainWindow>(), new ContainerControlledLifetimeManager());
            return Container.Resolve<Window>(GlobalConstants.MainWindowName);
        }

        /// <summary>
        /// Initialize shell
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            // Register views
            var regionManager = this.Container.Resolve<IRegionManager>();
            if (regionManager != null)
            {
                regionManager.RegisterViewWithRegion(RegionNames.LeftWindowCommandsRegion, typeof(Views.ShellTitlebarLeftWindowsCommands));
                regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(Views.ShellTitlebarRightWindowCommands));
                regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(Views.ShellSettingsFlyout));
            }

            Application.Current.MainWindow = (Window)this.Shell;
        }

        /// <summary>
        /// Show SplashScreen
        /// </summary>
        private void ShowSplashScreen()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
              {
                  Container.Resolve<IEventAggregator>().GetEvent<CloseSplashScreenEvent>().Publish(new CloseSplashScreenEvent());
              }));

            WaitForCreation = new AutoResetEvent(false);

            Thread t = new Thread(new ThreadStart(
              () =>
              {
                  Dispatcher.CurrentDispatcher.BeginInvoke(
                     (Action)(() =>
                     {
                         // Register SplashScreen
                         Container.RegisterInstance<Views.SplashScreen>("SplashScreen", new Views.SplashScreen(), new ContainerControlledLifetimeManager());
                         var splash = Container.Resolve<Views.SplashScreen>("SplashScreen");

                         // Subscribe for Closing-Event
                         Container.Resolve<IEventAggregator>().GetEvent<CloseSplashScreenEvent>().Subscribe(e => splash.Dispatcher.BeginInvoke((Action)(() => { splash.DataContext = null; splash.Dispatcher.InvokeShutdown(); splash.Close(); })), ThreadOption.PublisherThread, true);

                         splash.Show();

                         WaitForCreation.Set();
                     }));

                  Dispatcher.Run();
              }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            WaitForCreation.WaitOne();
        }

        /// <summary>
        /// Initialize modules
        /// </summary>
        protected override void InitializeModules()
        {
            base.InitializeModules();

            // Show SplashScreen
            this.ShowSplashScreen();

            // Connection-Management
            Container.Resolve<IEventAggregator>().GetEvent<SplashScreenStatusMessageUpdateEvent>().Publish("Connection module ...");
            IModule connectionModule = Container.Resolve<VersatileMediaManager.ConnectionManagement.ConnectionManagementModule>();
            connectionModule.Initialize();

            // Media Information
            Container.Resolve<IEventAggregator>().GetEvent<SplashScreenStatusMessageUpdateEvent>().Publish("Media-Information module ...");
            IModule mediaInformationModule = Container.Resolve<VersatileMediaManager.MediaInformation.MediaInformationModule>();
            mediaInformationModule.Initialize();

            // Kodi Library-Management
            Container.Resolve<IEventAggregator>().GetEvent<SplashScreenStatusMessageUpdateEvent>().Publish("Kodi-Management module ...");
            IModule libraryManagementModule = Container.Resolve<VersatileMediaManager.KodiManagement.KodiManagementModule>();
            libraryManagementModule.Initialize();

            // PVR-Management
            Container.Resolve<IEventAggregator>().GetEvent<SplashScreenStatusMessageUpdateEvent>().Publish("PVR-Management module ...");
            IModule pvrManagementModule = Container.Resolve<VersatileMediaManager.PvrManagement.PvrManagementModule>();
            pvrManagementModule.Initialize();

            // Local media management
            Container.Resolve<IEventAggregator>().GetEvent<SplashScreenStatusMessageUpdateEvent>().Publish("Local-Media-Management module ...");
            IModule localMediaManagementModule = Container.Resolve<VersatileMediaManager.LocalMediaManagement.LocalMediaManagementModule>();
            localMediaManagementModule.Initialize();

            // Help and Info
            Container.Resolve<IEventAggregator>().GetEvent<SplashScreenStatusMessageUpdateEvent>().Publish("Help and Info module ...");
            IModule helpAndInforModule = Container.Resolve<VersatileMediaManager.HelpAndInfo.HelpAndInfoModule>();
            helpAndInforModule.Initialize();

            // Udpate Status-Bar
            string localizedMessage = Container.Resolve<ILocalizerService>(ServiceNames.LocalizerService).GetLocalizedString("VersatileMediaManager.Shell:Resources:ShellReadyStatusBarMessage");
            Container.Resolve<IEventAggregator>().GetEvent<UpdateStatusBarMessageEvent>().Publish(localizedMessage);

            // Show MainWindow
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            //ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            //moduleCatalog.AddModule(typeof(VersatileMediaManager.ConnectionManagement.ConnectionManagementModule));
            //moduleCatalog.AddModule(typeof(VersatileMediaManager.DataServices.DataServicesModule));
            //moduleCatalog.AddModule(typeof(VersatileMediaManager.KodiManagement.KodiManagementModule));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Global application commands
            Container.RegisterType<IApplicationCommands, ApplicationCommandsProxy>();

            // Logging-Service
            Container.RegisterInstance<ILoggingService>(ServiceNames.LoggingService, Container.Resolve<LoggingService>(), new ContainerControlledLifetimeManager());

            // Flyout service
            Container.RegisterInstance<IFlyoutService>(ServiceNames.FlyoutService, Container.Resolve<FlyoutService>(), new ContainerControlledLifetimeManager());

            // Message display service
            Container.RegisterInstance<IMessageDisplayService>(ServiceNames.MetroMessageDisplayService, Container.Resolve<MetroMessageDisplayService>(), new ContainerControlledLifetimeManager());

            // Localizer-Service
            this.Container.RegisterInstance(typeof(ILocalizerService),
                ServiceNames.LocalizerService,
                new Services.LocalizerService("de-DE"),
                new Microsoft.Practices.Unity.ContainerControlledLifetimeManager());
        }
    }
}