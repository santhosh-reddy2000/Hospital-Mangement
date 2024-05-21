using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Models
{
    [Serializable]
    public class BaseUrls
    {
        public string WebApp { get; set; } = string.Empty;
        public string DataProvider { get; set; } = string.Empty;
        public string SignalR { get; set; } = string.Empty;
    }
}
