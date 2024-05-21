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
    public class Doctor : CommonProperties
    {
        [JsonProperty]
        public Guid Id { get; set; }

        [JsonProperty]
        public Guid BranchId { get; set; }

        [JsonProperty]
        public string? DoctorName { get; set; }

        [JsonProperty]
        public string? Specialization {  get; set; }

        [JsonProperty]
        public string? Qualificaton { get; set; }

        [JsonProperty]
        public string? Country { get; set; }

        [JsonProperty]
        public override string? Address { get; set; }

        [JsonProperty]
        public long MobileNumber { get; set; }

        [JsonProperty]
        public override string? Email {  get; set; }

        [JsonProperty]
        public string? LanguageKnow { get; set; }

        [JsonProperty]
        public string? Gender { get; set; }

        [JsonProperty]
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
