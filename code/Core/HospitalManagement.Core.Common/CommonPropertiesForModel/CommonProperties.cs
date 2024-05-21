using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.CommonPropertiesForModel
{
    public abstract class CommonProperties
    {
        [JsonProperty]
        public abstract string? Address { get; set; }

        [JsonProperty]
        public abstract string? Email { get; set; }
    }
}
