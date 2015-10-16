using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersatileMediaManager.PvrManagement.Contracts.Model
{
    public class PvrManagementMenuItem : BindableBase
    {
        private string name;

        /// <summary>
        /// The menu item name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { SetProperty<string>(ref this.name, value); }
        }

        private object content;

        /// <summary>
        /// The content to show
        /// </summary>
        public object Content
        {
            get { return content; }
            set { SetProperty<object>(ref this.content, value); }
        }
    }
}