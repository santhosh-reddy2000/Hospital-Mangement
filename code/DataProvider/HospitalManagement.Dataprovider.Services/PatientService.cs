using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using HospitalManagement.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Dataprovider.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public APIResult<bool> AddPatient(Patient patient)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isAdded = _patientRepository.AddPatient(patient);
            if (isAdded)
            {
                result.Result = true;
                result.Message.Message = "Sucessfully patinet added to the doctor";
            }
            else
            {
                result.Result = false;
                APIResultHelper.UpdateError("Failed to add patient to the doctor", result);
            }
            return result;
        }

        public APIResult<Patient> GetPatient(Guid patientId)
        {
            APIResult<Patient> result = new APIResult<Patient>();
            Patient patient = _patientRepository.GetPatient(patientId);
            if (patient != null)
            {
                result.Result = patient;
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to get patinet information from the doctor", result);
            }
            return result;
        }

        public APIResult<bool> UpdatePatient(Patient patient)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isUpdated = _patientRepository.UpdatePatient(patient);
            if (isUpdated)
            {
                result.Result = true;
                result.Message.Message = "Patient details updated successfully";
            }
            else
            {
                result.Result = false;
                APIResultHelper.UpdateError("Failed to update Patient information", result);
            }
            return result;

        }

        public APIResult<bool> DeletePatient(Guid patientId)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isDeleted = _patientRepository.DeletePatient(patientId);
            if (isDeleted)
            {
                result.Result = true;
                result.Message.Message = "Patient deleted successfully with the provided id";
            }
            else
            {
                result.Result = false;
                APIResultHelper.UpdateError("Failed to delete the patient information", result);
            }
            return result;
        }

        public APIResult<List<Patient>> GetAllPatients()
        {
            APIResult<List<Patient>> result = new APIResult<List<Patient>>();
            List<Patient> patients = _patientRepository.GetAllPatients();
            if (patients != null && patients.Any())
            {
                result.Result = patients;

            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("No patients were found", result);
            }
            return result;
        }

    }
}
