using System.Collections.Generic;
using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    [XmlRoot(ElementName = "e2deviceinfo", Namespace = "", IsNullable = false)]
    public class DeviceInfo
    {
        private string enigmaVersion;

        [XmlElement("e2enigmaversion")]
        public string EnigmaVersion
        {
            get { return enigmaVersion; }
            set { this.enigmaVersion = value; }
        }

        private string imageVersion;

        [XmlElement("e2imageversion")]
        public string ImageVersion
        {
            get { return imageVersion; }
            set { this.imageVersion = value; }
        }

        private string webIfVersion;

        [XmlElement("e2webifversion")]
        public string WebIfVersion
        {
            get { return webIfVersion; }
            set { this.webIfVersion = value; }
        }

        private string fpVersion;

        [XmlElement("e2fpversion")]
        public string FPVersion
        {
            get { return fpVersion; }
            set { fpVersion = value; }
        }

        private string deviceName;

        [XmlElement("e2devicename")]
        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }
        
        private List<Tuner> installedTuners = new List<Tuner>();

        [XmlArray("e2frontends")]
        [XmlArrayItem("e2frontend")]
        public List<Tuner> InstalledTuners
        {
            get { return installedTuners; }
            set { this.installedTuners = value; }
        }

        private List<NetworkInterface> installedNetworkInterfaces = new List<NetworkInterface>();

        [XmlArray("e2network")]
        [XmlArrayItem("e2interface")]
        public List<NetworkInterface> InstalledNetworkInterfaces
        {
            get { return installedNetworkInterfaces; }
            set { this.installedNetworkInterfaces = value; }
        }

        private List<Hdd> installedHdds = new List<Hdd>();

        [XmlArray("e2hdds")]
        [XmlArrayItem("e2hdd")]
        public List<Hdd> InstalledHdds
        {
            get { return installedHdds; }
            set { this.installedHdds = value; }
        }
    }
}