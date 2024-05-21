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
    public  class PatientRepository : IPatientRepository
    {
        private readonly ILogger _logger;
        private HospitalDBConnectionInfo _hospitalDBConnectionInfo;
        private const int RETRY_COUNT = 3;
        public PatientRepository(ILoggerFactory loggerFactory, HospitalDBConnectionInfo hospitalDBConnectionInfo)
        {
            _logger = loggerFactory.CreateLogger<HospitalSQLRepository>();
            _hospitalDBConnectionInfo = hospitalDBConnectionInfo;
        }

        public bool AddPatient(Patient patient)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        context.Add(patient);
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error occured on adding patient to the doctor");
                }
            }
            return false;

        }


        public Patient GetPatient(Guid patientId)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Patient? patient = context.Patient.FirstOrDefault(d => d.Id == patientId);
                        return patient;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on retrieving the patient information with the provided id");
                }
            }
            return null;
        }

        public bool UpdatePatient(Patient patient)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Patient? patient1 = context.Patient.FirstOrDefault(d => d.Id == patient.Id);
                        if (patient1 != null)
                        {
                            context.Update(patient);
                        }
                        else
                        {
                            context.Add(patient);
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
                    _logger.LogCritical(0, ex.Message, "Error on updating the patient information");
                }
            }
            return false;
        }

        public bool DeletePatient(Guid patientId)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Patient? patient = context.Patient.FirstOrDefault(d => d.Id == patientId);
                        if (patient != null)
                        {
                            context.Remove(patient);
                            context.SaveChanges();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "error on deleting patient with the provided doctorid");
                }
            }
            return false;

        }

        public List<Patient> GetAllPatients()
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        List<Patient> patients = context.Patient.ToList();
                        return patients;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "error on retrieving all patients");
                }
            }
            return null;
        }

    }
}
