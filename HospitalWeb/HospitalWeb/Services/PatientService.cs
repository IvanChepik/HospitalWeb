using HospitalDataAccess;
using HospitalDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Services
{
    public class PatientService
    {
        private readonly HospitalContext _hospitalContext;

        public PatientService(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        public async Task<List<Patient>> GetPatientsAsync(string userId)
        {
            return await _hospitalContext.Patients.ToListAsync();
        }

        public async Task<Patient> AddPatientsAsync(string userId, Patient patient)
        {
            await _hospitalContext.Patients.AddAsync(patient);

            await _hospitalContext.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> GetPatientAsync(long patientId, string userId)
        {
            return await _hospitalContext.Patients
                .Include(x => x.PatientDatas)
                .Include(x => x.NutritionSupports)
                .ThenInclude(x => x.Drug)
                .FirstOrDefaultAsync(x => x.PatientId == patientId);
        }
    }
}
