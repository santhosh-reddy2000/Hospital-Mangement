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
    public class PatientController : Controller
    {
        private ILogger _logger;
        private IPatientService _patientService;
        public PatientController(ILoggerFactory loggerFactory, IPatientService patientService)
        {
            _logger = loggerFactory.CreateLogger<DoctorController>();
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Default()
        {
            return Ok("You have successfully reached the Patient Controller");
        }



        [HttpPost(nameof(AddPatient))]
        public IActionResult AddPatient([FromBody] Patient patient)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _patientService.AddPatient(patient);
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

        [HttpGet(nameof(GetPatient))]
        public IActionResult GetPatient([FromQuery] Guid patientId)
        {
            APIResult<Patient> result = new APIResult<Patient>();
            try
            {
                result = _patientService.GetPatient(patientId);
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

        [HttpPost(nameof(UpdatePatient))]
        public IActionResult UpdatePatient([FromBody] Patient patient)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _patientService.UpdatePatient(patient);
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

        [HttpDelete(nameof(DeletePatient))]
        public IActionResult DeletePatient([FromQuery] Guid patientId)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                result = _patientService.DeletePatient(patientId);
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

        [HttpGet(nameof(GetAllPatients))]
        public IActionResult GetAllPatients()
        {
            APIResult<List<Patient>> result = new APIResult<List<Patient>>();
            try
            {
                result = _patientService.GetAllPatients();
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
