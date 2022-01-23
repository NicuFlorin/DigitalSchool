using System;
using System.Collections.Generic;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public Cohort Cohort { get; set; }
        public int CohortId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinal { get; set; }
        public Context Category { get; set; }
        public int CategoryId { get; set; }
        public AppUser Teacher { get; set; }
        public int? TeacherId { get; set; }

        public int NoOfSections { get; set; }
        public bool isWeekFormat { get; set; }

        public ICollection<Upload> Uploads { get; set; }
        // public ICollection<Folder> Folders { get; set; }
        public ICollection<Section> Sections { get; set; }


    }
}