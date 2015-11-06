using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    public class Location
    {
        private string name;

        /// <summary>
        /// Name
        /// </summary>
        [XmlElement("e2location")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
