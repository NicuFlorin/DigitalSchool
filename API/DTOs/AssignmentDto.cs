using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AssignmentDto : UploadDto
    {
        public DateTime SubmissionFrom { get; set; }
        public DateTime DueDate { get; set; }
        public decimal MaximumGrade { get; set; }
        public decimal GradeToPass { get; set; }
    }
}