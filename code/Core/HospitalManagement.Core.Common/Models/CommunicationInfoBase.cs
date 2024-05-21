using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Models
{
    public abstract class CommunicationInfoBase
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public string SignalR { get; set; }
    }
}
