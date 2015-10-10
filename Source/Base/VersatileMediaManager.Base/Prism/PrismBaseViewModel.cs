using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace VersatileMediaManager.Base.Prism
{
    public abstract class PrismBaseViewModel : BindableBase
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PrismBaseViewModel()
        {
            // Initialize
            this.UnityContainer = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUnityContainer>();
            this.RegionManager = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IRegionManager>();
            this.EventAggregator = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        #region Properties

        /// <summary>
        /// The Unity container
        /// </summary>
        public IUnityContainer UnityContainer { get; private set; }

        /// <summary>
        /// The region manager
        /// </summary>
        public IRegionManager RegionManager { get; private set; }

        /// <summary>
        /// The EventAggregator
        /// </summary>
        public IEventAggregator EventAggregator { get; private set; }

        #endregion Properties
    }
}