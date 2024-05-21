using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Common.Interfaces
{
    public interface IPatientService
    {
        APIResult<bool> AddPatient(Patient patient);

        APIResult<Patient> GetPatient(Guid patientId);

        APIResult<bool> UpdatePatient(Patient patient);

        APIResult<bool> DeletePatient(Guid patientId);

        APIResult<List<Patient>> GetAllPatients();
    }
}
