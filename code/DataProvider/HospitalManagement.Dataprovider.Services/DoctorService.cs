using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Dataprovider.Services
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public APIResult<bool> AddDoctor(Doctor doctor)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isAdded = _doctorRepository.AddDoctor(doctor);
            if (isAdded)
            {
                result.Result = true;
                result.Message.Message = "Sucessfully doctor added to the branch";
            }
            else
            {
                result.Result = false;
                APIResultHelper.UpdateError("Failed to add doctor to the branch", result);
            }
            return result;
        }

        public APIResult<Doctor> GetDoctor(Guid doctorId)
        {
            APIResult<Doctor> result = new APIResult<Doctor>();
            Doctor doctor = _doctorRepository.GetDoctor(doctorId);
            if (doctor != null)
            {
                result.Result = doctor;
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to get doctor information from the branch", result);
            }
            return result;
        }

        public APIResult<bool> UpdateDoctor(Doctor doctor)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isUpdated = _doctorRepository.UpdateDoctor(doctor);
            if (isUpdated)
            {
                result.Result = true;
                result.Message.Message = "Doctor details updated successfully";
            }
            else
            {
                result.Result = false;
                APIResultHelper.UpdateError("Failed to update Doctor information", result);
            }
            return result;

        }

        public APIResult<bool> DeleteDoctor(Guid doctorId)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isDeleted = _doctorRepository.DeleteDoctor(doctorId);
            if (isDeleted)
            {
                result.Result = true;
                result.Message.Message = "Doctor deleted successfully with the provided id";
            }
            else
            {
                result.Result = false;
                APIResultHelper.UpdateError("Failed to delete the doctor information", result);
            }
            return result;
        }

        public APIResult<List<Doctor>> GetAllDoctors()
        {
            APIResult<List<Doctor>> result = new APIResult<List<Doctor>> ();
            List<Doctor> doctors = _doctorRepository.GetAllDoctors();
            if (doctors != null && doctors.Any())
            {
                result.Result = doctors;

            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("No branches were found", result);
            }
            return result;
        }
    }
}
