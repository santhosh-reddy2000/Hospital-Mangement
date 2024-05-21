using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using HospitalManagement.DataProvider.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalManagement.Repository
{
    public class HospitalSQLRepository : IHospitalSQLRepository
    {
        private readonly ILogger _logger;
        private HospitalDBConnectionInfo _hospitalDBConnectionInfo;
        private const int RETRY_COUNT = 3;
        public HospitalSQLRepository(ILoggerFactory loggerFactory, HospitalDBConnectionInfo hospitalDBConnectionInfo)
        {
            _logger = loggerFactory.CreateLogger<HospitalSQLRepository>();
            _hospitalDBConnectionInfo = hospitalDBConnectionInfo;
        }

        public bool Create<T>(T data) where T : class
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        context.Add<T>(data);
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error in adding headoffice");
                }
            }
            return false;
        }

        public HeadOffice GetHeadOffice(Guid headOfficeId)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {

                        HeadOffice? headOffice = context.HeadOffice.FirstOrDefault(h => h.Id == headOfficeId);
                        if (headOffice != null)
                        {
                            return headOffice;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on retrieving headoffice with the provided id");
                }
            }
            return null;
        }

        public bool UpdateHeadoffice(HeadOffice headOffice)
        {
            for (int i = 0;i < RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        HeadOffice? headoffice = context.HeadOffice.FirstOrDefault(h => h.Id == headOffice.Id);
                        if (headoffice != null)
                        {
                            context.Update(headOffice);
                        }
                        else
                        {
                            context.Add(headOffice);
                        }

                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }  
                }
                catch(Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on updating headoffice");
                }
            }
            return false;

        }

        public bool DeleteHeadOffice(Guid headOfficeId)
        {
            for (int i = 0; i < RETRY_COUNT;i++)
            {
                try
                {
                    using(HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        HeadOffice? headOffice = context.HeadOffice.FirstOrDefault(h => h.Id == headOfficeId);
                        if (headOffice != null)
                        {
                            context.Remove(headOffice);
                            context.SaveChanges();
                            return true;
                        }  
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on deleting the headoffice with the providedid");
                }
            }
            return false;
        }

        public List<HeadOffice> GetAllHeadOffices()
        {
            for (int i = 0;i < RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        List<HeadOffice> headOffices = context.HeadOffice.ToList();
                        return headOffices;
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on retrieving all headoffices");
                }
            }
            return null;
        }
    }
}
