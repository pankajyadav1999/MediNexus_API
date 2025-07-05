using HospitalData.Dbcontexts;
using HospitalData.Interfaces;
using HospitalModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalData.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HospitalDbContext _context;

        public UserRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await _context.users.AddAsync(user);
        }

        public async Task<User?> GetUserAsync(string username, string password)
        {
            return await _context.users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }


    }
}
