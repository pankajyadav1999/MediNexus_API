using HospitalModels.Entities;

namespace HospitalData.Interfaces
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient); //----only----for -----POST ----now---//
    }
}
