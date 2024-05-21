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
    public class BranchRepository : IBranchRepository
    {
        private readonly ILogger _logger;
        private HospitalDBConnectionInfo _hospitalDBConnectionInfo;
        private const int RETRY_COUNT = 3;
        public BranchRepository(ILoggerFactory loggerFactory, HospitalDBConnectionInfo hospitalDBConnectionInfo)
        {
            _logger = loggerFactory.CreateLogger<HospitalSQLRepository>();
            _hospitalDBConnectionInfo = hospitalDBConnectionInfo;
        }

        public bool AddBranch(Branch branch)
        {
            for (int i = 0; i < RETRY_COUNT; i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        context.Add(branch);
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on adding branch to the headoffice");
                }
            }
            return false;
        }

        public Branch GetBranch(Guid branchId)
        {
            for (int i = 0;i < RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {

                        Branch? branch = context.Branch.FirstOrDefault(b => b.Id == branchId);
                        return branch;

                    }
                }
                catch(Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "Error on retrieving the branch information with the provided id");
                }
            }
            return null;
        }

        public bool UpdateBranch(Branch branch)
        {
            for(int i = 0; i < RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Branch? Branch = context.Branch.FirstOrDefault(h => h.Id == branch.Id);
                        if (Branch != null)
                        {
                            context.Update(branch);
                        }
                        else
                        {
                            context.Add(branch);
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
                    _logger.LogCritical(0, ex.Message, "Error on updating the branch information");
                }  
            }
            return false;
        }

        public bool DeleteBranch(Guid branchId)
        {
            for (int i = 0;i < RETRY_COUNT;i++)
            {
                try
                {
                    using (HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {
                        Branch? branch = context.Branch.FirstOrDefault(h => h.Id == branchId);
                        if (branch != null)
                        {
                            context.Remove(branch);
                            context.SaveChanges();
                            return true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "error on deleting the branch with the provided id");
                }
            }
            return false;
        }
        
        public List<Branch> GetAllBranches()
        {
            for (int i = 0; i < RETRY_COUNT;i++)
            {
                try
                {
                    using(HospitalDBContext context = new HospitalDBContext(_hospitalDBConnectionInfo))
                    {

                        List<Branch> branches = context.Branch.ToList();
                        return branches;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(0, ex.Message, "error on retrieving all branches information");
                }
            }
            return null;
        }
    }
}
