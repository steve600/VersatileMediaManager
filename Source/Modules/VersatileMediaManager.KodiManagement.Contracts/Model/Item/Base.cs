using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCManagementStudio.Domain.TrackableEntities;

namespace XBMCManagementStudio.Domain.Models.Item.Details
{
    public class Base : XbmcModelBase
    {
        private string label;

        /// <summary>
        /// Label
        /// </summary>
        [JsonProperty("label")]
        public string Label
        {
            get { return label; }
            set { this.SetProperty<string>(ref this.label, value); }
        }
    }
}
