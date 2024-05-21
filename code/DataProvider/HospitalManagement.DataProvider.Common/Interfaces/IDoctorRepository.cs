using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataProvider.Common.Interfaces
{
    public interface IDoctorRepository
    {
        bool AddDoctor(Doctor doctor);

        Doctor GetDoctor(Guid doctorId);

        bool UpdateDoctor(Doctor doctor);

        bool DeleteDoctor(Guid doctorId);

        List<Doctor> GetAllDoctors();
    }
}
