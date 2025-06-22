using HospitalModels.Entities;

namespace HospitalData.Interfaces
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient); //----only----for -----POST ----now---//
        Task<List<Patient>> GetList_Patient(); //---list ----api---//
        Task<Patient?> GetByIdAsync(int Id);//-----GetPatientById----//
        void DeletePatientAsync(Patient patient);//----delete-----//
    }
}
