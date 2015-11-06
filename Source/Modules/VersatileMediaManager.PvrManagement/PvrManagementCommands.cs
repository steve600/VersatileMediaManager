using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;

namespace VersatileMediaManager.PvrManagement
{
    public static class PvrManagementCommands
    {
        /// <summary>
        /// Add timer command
        /// </summary>
        public static CompositeCommand AddTimerCommand = new CompositeCommand();
    }

    public interface IPvrManagementCommands
    {
        CompositeCommand AddTimerCommand { get; }
    }

    public class PvrManagementCommandsProxy : IPvrManagementCommands
    {
        /// <summary>
        /// Show flyout command
        /// </summary>
        public CompositeCommand AddTimerCommand
        {
            get { return PvrManagementCommands.AddTimerCommand; }
        }
    }
}