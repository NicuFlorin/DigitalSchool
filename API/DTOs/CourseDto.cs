using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CohortId { get; set; }
        public int TeacherId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinal { get; set; }
        public int NoOfSections { get; set; }
        public bool isWeekFormat { get; set; }
        public ICollection<SectionDto> Sections { get; set; }
        public ICollection<UploadDto> Uploads { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string CohortName { get; set; }
    }
}