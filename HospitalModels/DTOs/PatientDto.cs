namespace HospitalModels.DTOs
{
    public class PatientDto
    {
        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

}
