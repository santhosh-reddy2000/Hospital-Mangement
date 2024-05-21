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
    public class Branch : CommonProperties
    {
        [JsonProperty]
        public Guid Id { get; set; }

        [JsonProperty]
        public Guid HeadofficeList { get; set; }

        [JsonProperty]
        public string? BranchName { get; set; } = string.Empty;

        [JsonProperty]
        public string? Branchcode { get; set; } = string.Empty;

        [JsonProperty]
        public string? BranchServices { get; set; } = string.Empty;

        [JsonProperty]
        public string? Managername { get; set; } = string.Empty;

        [JsonProperty]
        public override string? Address { get; set; } = string.Empty;
        [JsonProperty]
        public long MobileNo { get; set; }

        [JsonProperty]
        public override string? Email { get; set; } = string.Empty;

        [JsonProperty]
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
