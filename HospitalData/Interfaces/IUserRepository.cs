using HospitalModels.Entities;

namespace HospitalData.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync   (User user);
        Task<User?> GetUserAsync(string username, string password); //------user---//----get
    }
}