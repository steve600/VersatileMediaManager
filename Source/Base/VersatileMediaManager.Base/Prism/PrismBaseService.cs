using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace VersatileMediaManager.Base.Prism
{
    public abstract class PrismBaseService : BindableBase
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PrismBaseService()
        {
            // Initialize
            this.UnityContainer = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUnityContainer>();
        }

        #region Properties

        /// <summary>
        /// The Unity container
        /// </summary>
        public IUnityContainer UnityContainer { get; private set; }

        #endregion Properties
    }
}