using HospitalModels.DTOs;

namespace HospitalBusiness.Interfaces
{
    public interface IPatientManager
    {
        Task AddPatientAsync(PatientDto patientDto);
    }
}
