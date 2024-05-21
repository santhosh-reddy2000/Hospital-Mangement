using HospitalManagement.Core.Common.CommonPropertiesForModel;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [Serializable]
    public class HeadOffice : CommonProperties
    {
        [JsonProperty]
        public Guid Id { get; set; }

        [JsonProperty]
        public string? HeadOfficeName { get; set; }

        [JsonProperty]
        public int PinCode { get; set; }

        [JsonProperty]
        public override string? Address { get; set; }

        [JsonProperty]
        public string? Website { get; set; }

        [JsonProperty]
        public override string? Email { get; set;  }

        //[JsonProperty]
        //public List<Branch> Branches { get; set; } = new List<Branch>();
    }
}
