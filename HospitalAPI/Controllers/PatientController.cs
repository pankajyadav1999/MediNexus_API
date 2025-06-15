using HospitalBusiness.Interfaces;
using HospitalModels.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager _patientManager;

        public PatientController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto patientDto)
        {
            await _patientManager.AddPatientAsync(patientDto);
            return Ok(new { message = "Patient added successfully" });
        }
    }
}
