using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Windows;
using VersatileMediaManager.Base.Prism;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.PvrManagement.Contracts.Interfaces;
using VersatileMediaManager.PvrManagement.Services;

namespace VersatileMediaManager.PvrManagement
{
    public class PvrManagementModule : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public PvrManagementModule(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
            // Register-Services
            this.UnityContainer.RegisterType<IEnigma2WebInterfaceQueuingService, Enigma2WebInterfaceQueuingService>(ServiceNames.Enigma2WebInterfaceQueuingService, new ContainerControlledLifetimeManager());

            // Register Home-View
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.PvrManagementHome));

            // Register flyouts
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(Views.PvrManagementFlyout));
        }

        /// <summary>
        /// Add Resource-Dictionaries
        /// </summary>
        public override void AddResourceDictionaries()
        {
            base.AddResourceDictionaries();

            var rd = new ResourceDictionary();

            rd.Source = new Uri("/VersatileMediaManager.PvrManagement;component/Styling/LookAndFeel.xaml", UriKind.RelativeOrAbsolute);

            Application.Current.Resources.MergedDictionaries.Add(rd);
        }
    }
}