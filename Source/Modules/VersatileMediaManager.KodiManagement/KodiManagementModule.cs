using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Windows;
using VersatileMediaManager.Base.Prism;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.KodiManagement.Contracts.Interfaces;
using VersatileMediaManager.KodiManagement.Services;

namespace VersatileMediaManager.KodiManagement
{
    public class KodiManagementModule : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public KodiManagementModule(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
            // Register services
            UnityContainer.RegisterInstance<IKodiMovieLibraryManagementService>(ServiceNames.KodiMovieLibraryManagementJsonService, new KodiMovieLibraryManagementJsonService(), new ContainerControlledLifetimeManager());

            // Home-View
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.KodiManagementHome));

            // Flyouts
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(Views.MovieLibraryManagementFlyout));
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(Views.LibraryManagementTilesFyout));
        }

        /// <summary>
        /// Add Resource-Dictionaries
        /// </summary>
        public override void AddResourceDictionaries()
        {
            base.AddResourceDictionaries();

            var rd = new ResourceDictionary();

            rd.Source = new Uri("/VersatileMediaManager.KodiManagement;component/Styling/LookAndFeel.xaml", UriKind.RelativeOrAbsolute);

            Application.Current.Resources.MergedDictionaries.Add(rd);
        }
    }
}