namespace HospitalModels.Entities
{
    public class Patient
    {
        public int Id { get; set; } // -----primary -key-----//

        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;
        
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }   
    }
}