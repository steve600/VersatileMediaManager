using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    public class Hdd
    {
        private string model;

        /// <summary>
        /// The model
        /// </summary>
        [XmlElement("e2model")]
        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }

        private string capacity;

        /// <summary>
        /// The capacity
        /// </summary>
        [XmlElement("e2capacity")]
        public string Capacity
        {
            get { return capacity; }
            set { this.capacity = value; }
        }

        private string freeSpace;

        /// <summary>
        /// Free space
        /// </summary>
        [XmlElement("e2free")]
        public string FreeSpace
        {
            get { return freeSpace; }
            set { this.freeSpace = value; }
        }
    }
}