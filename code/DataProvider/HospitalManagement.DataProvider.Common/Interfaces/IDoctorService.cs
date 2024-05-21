using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataProvider.Common.Interfaces
{
    public interface IDoctorService
    {
        APIResult<bool> AddDoctor(Doctor doctor);

        APIResult<Doctor> GetDoctor(Guid doctorId);

        APIResult<bool> UpdateDoctor(Doctor doctor);

        APIResult<bool> DeleteDoctor(Guid doctorId);

        APIResult<List<Doctor>> GetAllDoctors();
    }
}
