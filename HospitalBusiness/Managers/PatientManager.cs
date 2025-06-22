using AutoMapper;
using HospitalBusiness.Interfaces;
using HospitalData.UnitOfWork;
using HospitalModels.DTOs;
using HospitalModels.Entities;

namespace HospitalBusiness.Managers
{
    public class PatientManager : IPatientManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPatientAsync(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _unitOfWork.PatientRepository.AddAsync(patient);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<PatientDto>> GetPatientAsync()
        {
            var patients = await _unitOfWork.PatientRepository.GetList_Patient();
            var patientsDto = _mapper.Map<List<PatientDto>>(patients);
            return patientsDto;
        }

        public async Task UpdatePatient(PatientDto patientDto)
        {
        
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(patientDto.Id);

            
            if (patient == null)
                throw new ArgumentException("Patient not found");

            _mapper.Map(patientDto, patient);

            
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            if (patient == null)
                return false;

            _unitOfWork.PatientRepository.DeletePatientAsync(patient);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
