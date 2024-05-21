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

        public class Patient : CommonProperties
        {
            [JsonProperty]
            public Guid Id { get; set; }

            [JsonProperty]
            public Guid DoctorId { get; set; }
            [JsonProperty]
            public string PatientName { get; set; } = string.Empty;

            [JsonProperty]
            public int Age { get; set; }

            [JsonProperty]
            public DateTime AppointmentDate { get; set; }

            [JsonProperty]
            public string ReasonForVisit { get; set; } = string.Empty;

            [JsonProperty]
            public override string? Address { get; set; }

            [JsonProperty]
            public long MobileNumber { get; set; } 

            [JsonProperty]
            public override string? Email { get; set;  }

            [JsonProperty]
            public string LanguageKnown { get; set; } = string.Empty;

            [JsonProperty]
            public string Gender { get; set; } = string.Empty;

            [JsonProperty]
            public string BloodGroup { get; set; } = string.Empty;

            [JsonProperty]
            public string MartialStatus { get; set; } = string.Empty;

           
        }
    
}
