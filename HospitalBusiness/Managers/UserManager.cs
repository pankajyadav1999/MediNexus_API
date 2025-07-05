using AutoMapper;
using HospitalModels.Entities;
using HospitalModels.DTOs;
using HospitalBusiness.Interfaces;
using HospitalData.UnitOfWork;
using HospitalData.Interfaces;

namespace HospitalBusiness.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task RegisterAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _unitOfWork.UserRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User?> AuthenticateAsync(UserDTO userDTO)
        {
            var user = await _unitOfWork.UserRepository.GetUserAsync(userDTO.Username, userDTO.Password);
            return user;
        }

    }
}