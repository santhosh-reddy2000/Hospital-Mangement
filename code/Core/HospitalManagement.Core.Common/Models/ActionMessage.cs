using HospitalManagement.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Models
{
    public class ActionMessage
    {
        public DateTime DateTimeInUTC { get; set; } = DateTime.UtcNow;

        public MessageTypeEnum MessageType { get; set; } = MessageTypeEnum.Normal;

        public string Message { get; set; } = string.Empty;
    }
}
