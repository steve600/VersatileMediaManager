using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2
{
    [XmlRoot("e2simplexmlresult")]
    public class XmlResult : BindableBase
    {
        private string status;

        [XmlElement("e2state")]
        public string Status
        {
            get { return status; }
            set { SetProperty<string>(ref this.status, value); }
        }

        private string statusText;

        [XmlElement("e2statetext")]
        public string StatusText
        {
            get { return statusText; }
            set { SetProperty<string>(ref this.statusText, value); }
        }
    }
}