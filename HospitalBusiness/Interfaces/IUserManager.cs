using HospitalModels.DTOs;
using HospitalModels.Entities;

namespace HospitalBusiness.Interfaces  
{
    public interface IUserManager
    {
        Task RegisterAsync(UserDTO userDTO);
        Task<User?> AuthenticateAsync(UserDTO userDTO);
    }
}
