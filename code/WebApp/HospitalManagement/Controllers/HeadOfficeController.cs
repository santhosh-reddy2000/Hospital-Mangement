using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route(RouteConstants.BaseRoute)]
    [ApiController]
    public class HeadOfficeController : ControllerBase
    {
        private ILogger _logger;
        private IHeadOfficeService _headOfficeService;
        public HeadOfficeController(ILoggerFactory loggerFactory, IHeadOfficeService headOfficeService)
        {
            _logger = loggerFactory.CreateLogger<HeadOfficeController>(); 
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
            APIResult<bool> result = new APIResult<bool >();
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

        [HttpDelete(nameof(DeleteHeadOffice))]
        public IActionResult DeleteHeadOffice([FromQuery] Guid headOfficeId)
        {
            APIResult<bool> result = new APIResult<bool >();
            try
            {
                result = _headOfficeService.DeleteHeadOffice(headOfficeId);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch(Exception ex)
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
            }
            catch( Exception ex)
            {
                APIResultHelper.UpdateException(ex,result);
            }
            return BadRequest(result);
        }
    }
}
