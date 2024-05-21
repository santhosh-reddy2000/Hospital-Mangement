using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HospitalManagement.Controllers
{
    [Route(RouteConstants.BaseRoute)]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private ILogger _logger;
        private IBranchService _branchService;
        public BranchController(ILoggerFactory loggerFactory,IBranchService branchService)
        {
            _logger = loggerFactory.CreateLogger<BranchController>();
            _branchService = branchService;
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
                result = _branchService.AddBranch(branch);
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
                result = _branchService.GetBranch(branchId);
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
            APIResult<bool> result = new APIResult<bool >();
            try
            {
                result = _branchService.UpdateBranch(branch);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch(Exception ex)
            {
                APIResultHelper.UpdateException(ex ,result);
            }
            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteBranch))]
        public IActionResult DeleteBranch([FromQuery] Guid branchId)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _branchService.DeleteBranch(branchId);
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

                result = _branchService.GetAllBranches();
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
