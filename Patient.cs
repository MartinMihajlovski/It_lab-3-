using System.Collections.Generic;

namespace WebApplication8.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PatientCode { get; set; }
        public string Gender { get; set; } // "Male", "Female", итн.

        // Листа со ID на доктори на кои е доделен пациентот
        public List<int> DoctorIds { get; set; } = new List<int>();
    }
}
