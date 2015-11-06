using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersatileMediaManager.Infrastructure.Base;

namespace VersatileMediaManager.PvrManagement.ViewModels
{
    class AddTimerPopupViewModel : VersatileMediaManagerPopupViewModel
    {
        public override string Title
        {
            get
            {
                return "Timer hinzufügen";
            }
        }
    }
}
