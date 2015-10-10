using Microsoft.Practices.Unity;
using Prism.Regions;
using VersatileMediaManager.Base.Prism;

namespace VersatileMediaManager.MediaInformation
{
    public class MediaInformationModule : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public MediaInformationModule(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
        }
    }
}