using System.Collections.Generic;

namespace WebApplication8.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        // Ид на болницата каде што работи
        public int HospitalId { get; set; }

        // Листа со ID на пациенти кои ги лекува докторот
        public List<int> PatientIds { get; set; } = new List<int>();
    }
}
