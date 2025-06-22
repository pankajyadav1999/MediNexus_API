using HospitalBusiness.Interfaces;
using HospitalBusiness.Managers;
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

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto patientDto)
        {
            await _patientManager.AddPatientAsync(patientDto);
            return Ok(new { message = "Patient added successfully" });
        }
        // -----get----patient----list-----//
        [HttpGet("GetPatient")]
        public async Task<IActionResult> GetPatient()
        {
            var patient = await _patientManager.GetPatientAsync();
            return Ok(patient);
        }

        // ---update-patient-list----//
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            if (id != patientDto.Id)
                return BadRequest("Patient ID mismatch");

            await _patientManager.UpdatePatient(patientDto);
            return Ok(new { message = "Patient updated successfully" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientAsync(int id)
        {
            var result = await _patientManager.DeletePatientAsync(id);
            if (!result)
                return NotFound(new { message = "Patient not found" });

            return Ok(new { message = "Patient deleted successfully" });
        } 
    }
}
