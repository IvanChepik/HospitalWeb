using HospitalDataAccess.Models;
using HospitalWeb.Extensions.Identity;
using HospitalWeb.Models;
using HospitalWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalWeb.Controllers
{
    [Route("patients")]
    public class PatientController : Controller
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetPatients()
        {
            var currentUserId = User.GetUserId();

            var patients = await _patientService.GetPatientsAsync(currentUserId);

            return Ok(patients);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddPatients([FromBody]Patient patient)
        {
            var currentUserId = User.GetUserId();

            var newPatient = await _patientService.AddPatientsAsync(currentUserId, patient);

            return Ok(newPatient);
        }

        [HttpGet("{patientId:long}")]
        public async Task<IActionResult> GetPatientInfo(long patientId)
        {
            var currentUserId = User.GetUserId();
            var patient =  await _patientService.GetPatientAsync(patientId, currentUserId);
            return Ok(patient);
        }
    }
}
