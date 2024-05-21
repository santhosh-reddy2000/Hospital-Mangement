using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.DoctorRoutes;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.PatientRoutes;
using HospitalManagement.Core.Common.Interfaces;
using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly IDataProviderCommunicator _dataProviderCommunicator;
        public PatientService(IDataProviderCommunicator dataProviderCommunicator)
        {
            _dataProviderCommunicator = dataProviderCommunicator;
        }

        public APIResult<bool> AddPatient(Patient patient)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{PatientRouteConstants.AddPatient}", patient, "");

        }

        public APIResult<Patient> GetPatient(Guid patientId)
        {
            return _dataProviderCommunicator.GetServerResponse<Patient>($"{PatientRouteConstants.GetPatient}?patientId={patientId}", "");
        }

        public APIResult<bool> UpdatePatient(Patient patient)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{PatientRouteConstants.UpdatePatient}", patient, "");
        }

        public APIResult<bool> DeletePatient(Guid patientId)
        {
            return _dataProviderCommunicator.GetServerResponse<bool>($"{PatientRouteConstants.DeletePatient}?patientId= {patientId}", "");
        }

        public APIResult<List<Patient>> GetAllPatients()
        {
            return _dataProviderCommunicator.GetServerResponse<List<Patient>>($"{PatientRouteConstants.GetAllPatients}", "");
        }
    }
}
