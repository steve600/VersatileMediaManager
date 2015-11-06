using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    [XmlRoot("e2locations")]
    public class LocationList : BindableBase
    {
        private List<Location> items = new List<Location>();

        [XmlArrayItem("e2location")]
        public List<Location> Items
        {
            get { return items; }
            set { this.items = value; }
        }
    }
}