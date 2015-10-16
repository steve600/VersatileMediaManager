using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    public class Tuner
    {
        public Tuner() { }

        private string name;

        /// <summary>
        /// Name
        /// </summary>
        [XmlElement("e2name")]
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        private string model;

        /// <summary>
        /// Model
        /// </summary>
        [XmlElement("e2model")]
        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }
    }
}