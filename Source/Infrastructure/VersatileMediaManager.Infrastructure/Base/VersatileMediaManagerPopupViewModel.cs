using Prism.Commands;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.Infrastructure.Base
{
    public abstract class VersatileMediaManagerPopupViewModel : VersatileMediaManagerViewModelBase
    {
        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        public VersatileMediaManagerPopupViewModel()
        {
            this.InitializeCommands();
        }

        #endregion CTOR

        #region Commands

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void InitializeCommands()
        {
            this.ClosePopupCommand = new DelegateCommand(this.ClosePopup, this.CanClosePopup);
        }

        public ICommand ClosePopupCommand { get; private set; }

        private bool CanClosePopup()
        {
            return true;
        }

        private void ClosePopup()
        {
            if (this.RegionManager != null)
            {
                var view = this.RegionManager.Regions[RegionNames.DialogPopupRegion].ActiveViews.FirstOrDefault();
                if (view != null)
                {
                    this.RegionManager.Regions[RegionNames.DialogPopupRegion].Remove(view);
                }
            }
        }

        #endregion Commands

        #region Properties

        /// <summary>
        /// Title of the windows
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Size to content
        /// </summary>
        public virtual SizeToContent PopupSizeToContent
        {
            get
            {
                return SizeToContent.WidthAndHeight;
            }
        }

        /// <summary>
        /// Resize mode
        /// </summary>
        public virtual ResizeMode PopupResizeMode
        {
            get
            {
                return ResizeMode.NoResize;
            }
        }

        #endregion Properties
    }
}