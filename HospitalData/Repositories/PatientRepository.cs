using HospitalData.Dbcontexts;
using HospitalData.Interfaces;
using HospitalModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalData.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }
        // -=====post--api-----//
        public async Task AddAsync(Patient patient)
        {
            await _context.patients.AddAsync(patient);
        }
        // ====get-list-data====//
        public async Task<List<Patient>> GetList_Patient()
        {
            return await _context.patients.ToListAsync();
        }

        //------updated----patient-list---///
        public async Task<Patient?> GetByIdAsync(int Id)
        {
            return await _context.patients.FindAsync(Id);
        }

        // ------delete-----//

        public void DeletePatientAsync(Patient patient)
        {
            _context.patients.Remove(patient);
        }

    }
}
