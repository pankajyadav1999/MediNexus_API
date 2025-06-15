using AutoMapper;
using HospitalModels.DTOs;
using HospitalModels.Entities;

namespace HospitalAPI.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, PatientDto>(); // optional: if needed for GETs
        }
    }
}
