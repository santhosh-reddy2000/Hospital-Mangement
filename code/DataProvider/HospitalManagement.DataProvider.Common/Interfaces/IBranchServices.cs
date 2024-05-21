using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataProvider.Common.Interfaces
{
    public interface IBranchServices
    {
        APIResult<bool> AddBranch(Branch branch);

        APIResult<Branch> GetBranch(Guid branchId);

        APIResult<bool> UpdateBranch(Branch branch);

        APIResult<bool> DeleteBranch(Guid branchId);

        APIResult<List<Branch>> GetAllBranches();  
    }
}
