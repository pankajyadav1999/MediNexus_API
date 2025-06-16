using HospitalData.Dbcontexts;
using HospitalData.Interfaces;
using HospitalModels.Entities;

namespace HospitalData.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.patients.AddAsync(patient);
        }
    }
}
