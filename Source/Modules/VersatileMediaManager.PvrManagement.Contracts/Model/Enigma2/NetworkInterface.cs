using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    public class NetworkInterface
    {
        private string name;

        /// <summary>
        /// Name of the adapter
        /// </summary>
        [XmlElement("e2name")]
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        private string macAddress;

        /// <summary>
        /// The MAC-Address
        /// </summary>
        [XmlElement("e2mac")]
        public string MacAddress
        {
            get { return macAddress; }
            set { this.macAddress = value; }
        }

        private string dhcp;

        /// <summary>
        /// Flag if DHCP is enabled
        /// </summary>
        [XmlElement("e2dhcp")]
        public string DHCP
        {
            get { return dhcp; }
            set { this.dhcp = value; }
        }

        private string ip;

        /// <summary>
        /// The IP-Address
        /// </summary>
        [XmlElement("e2ip")]
        public string IP
        {
            get { return ip; }
            set { this.ip = value; }
        }

        private string gateway;

        /// <summary>
        /// The gateway
        /// </summary>
        [XmlElement("e2gateway")]
        public string Gateway
        {
            get { return gateway; }
            set { this.gateway = value; }
        }

        private string netmask;

        /// <summary>
        /// Netmask
        /// </summary>
        [XmlElement("e2netmask")]
        public string Netmask
        {
            get { return netmask; }
            set { this.netmask = value; }
        }
    }
}