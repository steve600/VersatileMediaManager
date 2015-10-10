using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.Infrastructure.Services
{
    public class MetroMessageDisplayService : IMessageDisplayService
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public MetroMessageDisplayService()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void ShowMessage(string title, string message)
        {
            // TODO: Use MahApps.Metro DialogCoordiantor
            ((MetroWindow)Application.Current.MainWindow)?.ShowMessageAsync(title, message);
        }
    }
}