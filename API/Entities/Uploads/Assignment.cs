using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Assignment : Upload
    {
        public DateTime SubmissionFrom { get; set; }
        public DateTime DueDate { get; set; }
        public double MaximumGrade { get; set; }
        public double GradeToPass { get; set; }
        public ICollection<AssignmentSubmit> AssignmentSubmits { get; set; }
    }
}