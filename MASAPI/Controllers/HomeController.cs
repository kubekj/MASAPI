using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MASAPI.DTOs;
using MASAPI.Models;
using MASAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MASAPI.Controllers
{
    [Route("api/overall")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHealthcareDbRepositories _IHealthcareDbRepositories;

        public HomeController(IHealthcareDbRepositories healthcareDbRepositories)
        {
            _IHealthcareDbRepositories = healthcareDbRepositories;
        }

        [HttpPost("{ID}")]
        public async Task<IActionResult> AssignDoctorToHospital([FromRoute] int ID, [FromBody] DoctorDTO doctor)
        { 
            var assignToHospital = await _IHealthcareDbRepositories.AssignDoctorToHospital(ID, doctor);

            if (assignToHospital == null)
                return BadRequest("Something went wrong");

            return Ok("Doctor added to hospital");
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetPatient([FromRoute] int ID)
        {
            var patient = await _IHealthcareDbRepositories.GetPatientFromDbAsync(ID);

            if (patient == null)
                return BadRequest("There is nothing to show");

            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _IHealthcareDbRepositories.GetHospitalsFromDbAsync();

            if (hospitals == null)
                return BadRequest("There is nothing to show");

            return Ok(hospitals);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int ID)
        {
            var isDeleteSuccesfull = await _IHealthcareDbRepositories.DeleteDoctor(ID);

            if (!isDeleteSuccesfull)
                return BadRequest("Removal failed");

            return Ok($"Doctor with id {ID} has been removed from database");
        }
    }
}

