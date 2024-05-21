using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.BranchRoutes;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.HeadOfficeRoutes;
using HospitalManagement.Core.Common.Interfaces;
using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class BranchService : IBranchService
    {
        private readonly IDataProviderCommunicator _dataProviderCommunicator;
        public BranchService(IDataProviderCommunicator dataProviderCommunicator) 
        {
            _dataProviderCommunicator = dataProviderCommunicator;
        }

        public APIResult<bool> AddBranch(Branch branch)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{BranchRouteConstants.AddBranch}", branch, "");
        }

        public APIResult<Branch> GetBranch(Guid branchId)
        {
            return _dataProviderCommunicator.GetServerResponse<Branch>($"{BranchRouteConstants.GetBranch}?branchId={branchId}","");
           // return _dataProviderCommunicator.PostToServer<Branch>($"{BranchRouteConstants.GetBranch}", branchId,"");
        
        }

        public APIResult<bool> UpdateBranch(Branch branch)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{BranchRouteConstants.UpdateBranch}", branch, "");
        }

        public APIResult<bool> DeleteBranch(Guid branchId)
        {
            return _dataProviderCommunicator.GetServerResponse<bool>($"{BranchRouteConstants.DeleteBranch}?branchId={branchId}","");
        }

        public APIResult<List<Branch>> GetAllBranches()
        {
            
            return _dataProviderCommunicator.GetServerResponse<List<Branch>>($"{BranchRouteConstants.GetAllBranches}", "");
        }
    }
}
