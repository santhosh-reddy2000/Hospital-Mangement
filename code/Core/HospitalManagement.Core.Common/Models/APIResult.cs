using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Models
{
    [Serializable]
    public class APIResult<T>
    {
        public bool Suceess { get; set; } = true;

        public ActionMessage Message { get; set; } = new ActionMessage();

        public T Result { get; set; }
    }
}
