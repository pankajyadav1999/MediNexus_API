using Microsoft.EntityFrameworkCore;
using HospitalModels.Entities;

namespace HospitalData.Dbcontexts
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Patient> patients { get; set; } = null!;
    }
}