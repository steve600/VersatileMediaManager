using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    public class Service
    {
        private string serviceReference;

        [XmlElement("e2servicereference")]
        public string ServiceReference
        {
            get { return serviceReference; }
            set { this.serviceReference = value; }
        }

        private string serviceName;

        [XmlElement("e2servicename")]
        public string ServiceName
        {
            get { return serviceName; }
            set { this.serviceName = value; }
        }
    }
}