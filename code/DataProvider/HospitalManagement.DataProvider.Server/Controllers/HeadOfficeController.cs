using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.DataProvider.Server.Controllers
{
    [Route(RouteConstants.BaseRoute)]
    [ApiController]
    public class HeadOfficeController : ControllerBase
    {
        private IHeadOfficeService _headOfficeService;
        public HeadOfficeController(IHeadOfficeService headOfficeService)
        {
            _headOfficeService = headOfficeService;
        }

        [HttpGet]
        public IActionResult Default()
        {
            return Ok("You have successfully reached the HeadOffice Controller");
        }

        [HttpPost(nameof(AddHeadOffice))]
        public IActionResult AddHeadOffice([FromBody] HeadOffice headOffice)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _headOfficeService.AddHeadOffice(headOffice);
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

        [HttpGet(nameof(GetHeadOffice))]
        public IActionResult GetHeadOffice([FromQuery] Guid headOfficeId)
        {
            APIResult<HeadOffice> result = new APIResult<HeadOffice>();
            try
            {
                result = _headOfficeService.GetHeadOffice(headOfficeId);
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

        [HttpPost(nameof(UpdateHeadoffice))]
        public IActionResult UpdateHeadoffice([FromBody] HeadOffice headOffice)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _headOfficeService.UpdateHeadoffice(headOffice);
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

        [HttpGet(nameof(DeleteHeadOffice))]
        public IActionResult DeleteHeadOffice([FromQuery] Guid headOfficeId)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                 result = _headOfficeService.DeleteHeadOffice(headOfficeId);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex) 
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);

        }

        [HttpGet(nameof(GetAllHeadOffices))]
        public IActionResult GetAllHeadOffices()
        {
            APIResult<List<HeadOffice>> result = new APIResult<List<HeadOffice>>();
            try
            {
                result = _headOfficeService.GetAllHeadOffices();
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }
    }
}
