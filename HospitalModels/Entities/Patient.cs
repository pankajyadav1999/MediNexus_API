using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalModels.Entities
{
    [Table("Patients")] //.  Explicitly mapping to SQL table `Patients
    public class Patient
    {
        public int Id { get; set; } // -----primary -key-----//

        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string ContactNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string BloodGroup { get; set; } = null!;

        public string? MedicalHistory { get; set; }

        public string? EmergencyContact { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}