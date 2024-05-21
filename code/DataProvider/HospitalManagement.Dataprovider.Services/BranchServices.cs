using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using HospitalManagement.DataProvider.Common.Models;
using HospitalManagement.Repository;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Dataprovider.Services
{
    public class BranchServices : IBranchServices
    {
        private IBranchRepository _branchRepository;
        public BranchServices(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public APIResult<bool> AddBranch(Branch branch)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isAdded = _branchRepository.AddBranch(branch);
            if (isAdded)
            {
                result.Result = true;
                result.Message.Message = "Successfully branch added to the headoffice";
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to add branch to the headoffice", result);
            }
            return result;
        }

        public APIResult<Branch> GetBranch(Guid branchId)
        {
            APIResult<Branch> result = new APIResult<Branch>();
            Branch branch = _branchRepository.GetBranch(branchId);
            if (branch != null )
            {
                result.Result = branch;
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("No branches are found with the provided id", result);
            }
            return result;
        }

        public APIResult<bool> UpdateBranch(Branch branch)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isUpdated = _branchRepository.UpdateBranch(branch);
            if (isUpdated)
            {
                result.Result = true;
                result.Message.Message = "Branch Updated successfully";
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to update the branch", result);
            }
            return result;
        }

        public APIResult<bool> DeleteBranch(Guid branchId)
        {
            APIResult<bool> result = new APIResult<bool>();
            bool isDeleted = _branchRepository.DeleteBranch(branchId);
            if (isDeleted)
            {
                result.Result = true;
                result.Message.Message = "Branch deleted successfully with the provided branchid";
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to delete to the branch",result);
            }
            return result;

        }

        public APIResult<List<Branch>> GetAllBranches()
        {
            APIResult<List<Branch>> result = new APIResult<List<Branch>>();
            List<Branch> branches = _branchRepository.GetAllBranches();

            if (branches != null && branches.Any())
            {
                result.Result = branches;
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
