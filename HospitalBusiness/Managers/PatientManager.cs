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
    }
}
