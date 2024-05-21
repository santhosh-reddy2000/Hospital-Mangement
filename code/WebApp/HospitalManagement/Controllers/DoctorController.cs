using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route(RouteConstants.BaseRoute)]
    [ApiController]
    public class DoctorController : Controller
    {
        private ILogger _logger;
        private IDoctorService _doctorService;
        public DoctorController(ILoggerFactory loggerFactory, IDoctorService doctorService)
        {
            _logger = loggerFactory.CreateLogger<DoctorController>();
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Default()
        {
            return Ok("You have successfully reached the Doctor Controller");
        }

        [HttpPost(nameof(AddDoctor))]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _doctorService.AddDoctor(doctor);
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

        [HttpGet(nameof(GetDoctor))]
        public IActionResult GetDoctor([FromQuery] Guid doctorId)
        {
            APIResult<Doctor> result = new APIResult<Doctor>();
            try
            {
                result = _doctorService.GetDoctor(doctorId);
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

        [HttpPost(nameof(UpdateDoctor))]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _doctorService.UpdateDoctor(doctor);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch( Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteDoctor))]
        public IActionResult DeleteDoctor([FromQuery] Guid doctorId)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _doctorService.DeleteDoctor(doctorId);
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

        [HttpGet(nameof(GetAllDoctors))]
        public IActionResult GetAllDoctors()
        {
            APIResult<List<Doctor>> result = new APIResult<List<Doctor>>();
            try
            {
                result = _doctorService.GetAllDoctors();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch ( Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
            }
            return BadRequest(result);
        }   
    }
}
