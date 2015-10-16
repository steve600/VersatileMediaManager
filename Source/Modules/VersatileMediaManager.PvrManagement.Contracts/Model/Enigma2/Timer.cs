using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    public class Timer
    {
        private string serviceRefence;

        [XmlElement("e2servicereference")]
        public string ServiceReference
        {
            get { return serviceRefence; }
            set { serviceRefence = value; }
        }

        private string serviceName;

        [XmlElement("e2servicename")]
        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        private string eit;

        [XmlElement("e2eit")]
        public string EIT
        {
            get { return eit; }
            set { eit = value; }
        }

        private string name;

        [XmlElement("e2name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        [XmlElement("e2description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string descriptionExtended;

        [XmlElement("e2descriptionextended")]
        public string DescriptionExtended
        {
            get { return descriptionExtended; }
            set { descriptionExtended = value; }
        }

        private string disabled;

        [XmlElement("e2disabled")]
        public string Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }

        private string timeBegin;

        [XmlElement("e2timebegin")]
        public string TimeBegin
        {
            get { return timeBegin; }
            set { timeBegin = value; }
        }

        private string timeEnd;

        [XmlElement("e2timeend")]
        public string TimeEnd
        {
            get { return timeEnd; }
            set { timeEnd = value; }
        }

        private string duration;

        [XmlElement("e2duration")]
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        private string startPrepare;

        [XmlElement("e2startprepare")]
        public string StartPrepare
        {
            get { return startPrepare; }
            set { startPrepare = value; }
        }

        private bool justPlay;

        [XmlElement(ElementName = "e2justplay", Type = typeof(bool))]
        public bool JustPlay
        {
            get { return justPlay; }
            set { justPlay = value; }
        }

        private int afterEvent;

        [XmlElement(ElementName = "e2afterevent", Type = typeof(int))]
        public int AfterEvent
        {
            get { return afterEvent; }
            set { afterEvent = value; }
        }

    }
}