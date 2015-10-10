using Microsoft.Practices.Unity;
using Prism.Regions;
using VersatileMediaManager.Base.Prism;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.HelpAndInfo
{
    public class HelpAndInfoModule : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public HelpAndInfoModule(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
            // Register views
            regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(Views.ShellTitlebarRightWindowCommands));
        }
    }
}