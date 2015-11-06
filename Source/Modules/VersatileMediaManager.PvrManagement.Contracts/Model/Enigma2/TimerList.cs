using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    [XmlRoot("e2timerlist")]
    public class TimerList : BindableBase
    {
        private List<Timer> items = new List<Timer>();

        [XmlElement("e2timer")]
        public List<Timer> Items
        {
            get { return items; }
            set { this.items = value; }
        }
    }
}