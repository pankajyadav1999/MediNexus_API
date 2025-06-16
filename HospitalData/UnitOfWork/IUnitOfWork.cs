using HospitalData.Interfaces;

namespace HospitalData.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
