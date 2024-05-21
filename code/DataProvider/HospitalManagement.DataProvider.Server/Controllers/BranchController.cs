using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.Dataprovider.Services;
using HospitalManagement.DataProvider.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.DataProvider.Server.Controllers
{
    [Route(RouteConstants.BaseRoute)]
    [ApiController]
    public class BranchController : Controller
    {
        private IBranchServices _branchServices;
        public BranchController(IBranchServices branchService)
        {
            _branchServices = branchService;
        }

        [HttpGet]
        public IActionResult Default()
        {
            return Ok("You have successfully reached the Branch Controller");
        }

        [HttpPost(nameof(AddBranch))]
        public IActionResult AddBranch([FromBody] Branch branch)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _branchServices.AddBranch(branch);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }

        [HttpGet(nameof(GetBranch))]
        public IActionResult GetBranch([FromQuery] Guid branchId)
        {
            APIResult<Branch> result = new APIResult<Branch>();
            try
            {
                result = _branchServices.GetBranch(branchId);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch(Exception ex)
            {
                APIResultHelper.UpdateException(ex,result);
            }
            return BadRequest(result);
        }

        [HttpPost(nameof(UpdateBranch))]
        public IActionResult UpdateBranch([FromBody] Branch branch)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _branchServices.UpdateBranch(branch);
                if (result != null)
                {
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }

        [HttpGet(nameof(DeleteBranch))]
        public IActionResult DeleteBranch([FromQuery] Guid branchId)
        {
            APIResult<bool> result = new APIResult<bool >();
            try
            {
                result = _branchServices.DeleteBranch(branchId);
                if (result != null)
                {
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }

        [HttpGet(nameof(GetAllBranches))]
        public IActionResult GetAllBranches()
        {
            APIResult<List<Branch>> result = new APIResult<List<Branch>>();
            try
            {
                result = _branchServices.GetAllBranches();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }
    }
}
