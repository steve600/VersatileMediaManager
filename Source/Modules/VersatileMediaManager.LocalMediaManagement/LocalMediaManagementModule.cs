﻿using Microsoft.Practices.Unity;
using Prism.Regions;
using VersatileMediaManager.Base.Prism;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.LocalMediaManagement
{
    public class LocalMediaManagementModule : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public LocalMediaManagementModule(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.LocalMediaManagementHome));
        }
    }
}