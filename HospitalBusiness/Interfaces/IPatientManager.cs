using HospitalModels.DTOs;

namespace HospitalBusiness.Interfaces
{
    public interface IPatientManager
    {
        Task AddPatientAsync(PatientDto patientDto);//-------addpatientasync----//
        Task<List<PatientDto>> GetPatientAsync(); //----getpatientasync-----//
        Task UpdatePatient(PatientDto patientDto);  //-----patient----update---//         
        Task<bool> DeletePatientAsync(int id); //-----delete--patient----async----//
    }

 
}
