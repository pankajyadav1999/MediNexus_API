using AutoMapper;
using HospitalModels.DTOs;
using HospitalModels.Entities;

namespace HospitalAPI.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PatientDto, Patient>(); //----post-api-controller-api----//
            CreateMap<Patient, PatientDto>(); // optional: if needed for GETs
            CreateMap<Patient, PatientDto>().ReverseMap(); //----update-add-maping--//

            CreateMap<UserDTO, User>().ReverseMap();//----register---//
            
            CreateMap<UserDTO, User>(); //--login -----//
            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
