using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using HospitalManagement.DataProvider.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ILogger _logger;
        private HospitalDBConnectionInfo _hospitalDBConnectionInfo;
        private const int RETRY_COUNT = 3;
        public DoctorRepository(ILoggerFactory loggerFactory, HospitalDBConnectionInfo hospitalDBConnectionInfo)
        {
            _logger = loggerFactory.CreateLogger<HospitalSQLRepository>();
            _hospitalDBConnectionInfo = hospitalDBConnectionInfo;
        }

        public bool AddDoctor(Doctor doctor)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using(HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        context.Add(doctor);
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error occured on adding doctor to the branch");
                }
            }
            return false;

        }

        public Doctor GetDoctor(Guid doctorId)
        {
            for (int i = 0; i< RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Doctor? doctor = context.Doctor.FirstOrDefault(d => d.Id == doctorId);
                        return doctor;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on retrieving the doctor information with the provided id");
                }
            }
            return null;
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            for (int i = 0;i< RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Doctor? Doctor = context.Doctor.FirstOrDefault(d => d.Id == doctor.Id);
                        if (Doctor != null)
                        {
                            context.Update(doctor);
                        }
                        else
                        {
                            context.Add(doctor);
                        }
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on updating the doctor information");
                }
            }
            return false;
        }

        public bool DeleteDoctor(Guid doctorId)
        {
            for (int i = 0; i< RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Doctor? doctor = context.Doctor.FirstOrDefault(d => d.Id == doctorId);
                        if (doctor != null)
                        {
                            context.Remove(doctor);
                            context.SaveChanges();
                            return true;    
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "error on deleting doctor with the provided doctorid");
                }
            }
            return false;
           
        }

        public List<Doctor> GetAllDoctors()
        {
            for ( int i = 0;i< RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        List<Doctor> doctors = context.Doctor.ToList();
                        return doctors;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "error on retrieving all doctors");
                }
            }
            return null;
        }
    }   
}
