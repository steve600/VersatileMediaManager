using Prism.Mvvm;
using System.Collections.Generic;

using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    [XmlRoot("e2servicelist")]
    public class ServiceList : BindableBase
    {
        private List<Service> items = new List<Service>();

        [XmlElement("e2service")]
        public List<Service> Items
        {
            get { return items; }
            set { this.items = value; }
        }
    }
}