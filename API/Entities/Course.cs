using System;

namespace API.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cohort Cohort { get; set; }
        public int CohortId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinal { get; set; }
        public Context Category { get; set; }
        public int CategoryId { get; set; }
        public AppUser Teacher { get; set; }
        public int TeacherId { get; set; }


    }
}