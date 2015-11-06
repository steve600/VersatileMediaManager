using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Windows;
using VersatileMediaManager.Base.Prism;
using VersatileMediaManager.Communication.Connections;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.ConnectionManagement.Manager;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.ConnectionManagement
{
    public class ConnectionManagementModule : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        public ConnectionManagementModule(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
            unityContainer.RegisterType<IConnectionFactory, ConnectionFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IConnectionManager, ConnectionManager>(GlobalConstants.ConnectionManager, new ContainerControlledLifetimeManager());

            regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(Views.ConnectionManagementTitlebarRightWindowCommands));
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(Views.ConnectionsFlyout));

            // Register views for navigation
            Prism.Unity.UnityExtensions.RegisterTypeForNavigation<Views.AddConnection>(this.UnityContainer, ViewNames.AddConnectionView);
        }

        /// <summary>
        /// Add Resource-Dictionaries
        /// </summary>
        public override void AddResourceDictionaries()
        {
            base.AddResourceDictionaries();

            var rd = new ResourceDictionary();

            rd.Source = new Uri("/VersatileMediaManager.ConnectionManagement;component/Styling/LookAndFeel.xaml", UriKind.RelativeOrAbsolute);

            Application.Current.Resources.MergedDictionaries.Add(rd);
        }
    }
}