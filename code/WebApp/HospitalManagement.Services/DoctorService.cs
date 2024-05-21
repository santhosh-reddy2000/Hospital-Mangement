using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.BranchRoutes;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.DoctorRoutes;
using HospitalManagement.Core.Common.Interfaces;
using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDataProviderCommunicator _dataProviderCommunicator;
        public DoctorService(IDataProviderCommunicator dataProviderCommunicator)
        {
            _dataProviderCommunicator = dataProviderCommunicator;
        }

        public APIResult<bool> AddDoctor(Doctor doctor)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{DoctorRouteConstants.AddDoctor}", doctor, "");

        }

        public APIResult<Doctor> GetDoctor(Guid doctorId)
        {
            return _dataProviderCommunicator.GetServerResponse<Doctor>($"{DoctorRouteConstants.GetDoctor}?doctorId={doctorId}", "");
        }

        public APIResult<bool> UpdateDoctor(Doctor doctor)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{DoctorRouteConstants.UpdateDoctor}", doctor, "");
        }

        public APIResult<bool> DeleteDoctor(Guid doctorId)
        {
            return _dataProviderCommunicator.GetServerResponse<bool>($"{DoctorRouteConstants.DeleteDoctor}?doctorId={doctorId}", "");
        }

        public APIResult<List<Doctor>> GetAllDoctors()
        {
            return _dataProviderCommunicator.GetServerResponse<List<Doctor>>($"{DoctorRouteConstants.GetAllDoctors}", "");
        }
    }
}
