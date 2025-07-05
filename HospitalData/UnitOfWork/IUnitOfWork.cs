using HospitalData.Interfaces;

namespace HospitalData.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }
        IUserRepository UserRepository { get; } 
        Task<int> SaveChangesAsync();
    }
}
