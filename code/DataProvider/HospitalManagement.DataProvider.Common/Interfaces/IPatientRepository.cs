using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataProvider.Common.Interfaces
{
    public interface IPatientRepository
    {
        bool AddPatient(Patient patient);

        Patient GetPatient(Guid patientId);

        bool UpdatePatient(Patient patient);

        bool DeletePatient(Guid patientId);

        List<Patient> GetAllPatients();

    }
}
