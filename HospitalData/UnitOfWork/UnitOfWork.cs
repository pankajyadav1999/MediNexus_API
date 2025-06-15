using HospitalData.Dbcontexts;
using HospitalData.Interfaces;
using HospitalData.Repositories;

namespace HospitalData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalDbContext _context;

        public UnitOfWork(HospitalDbContext context)
        {
            _context = context;
            PatientRepository = new PatientRepository(_context);
        }

        public IPatientRepository PatientRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
