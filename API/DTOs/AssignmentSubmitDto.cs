using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AssignmentSubmitDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Text { get; set; }
        public string Feedback { get; set; }

        public double Grade { get; set; }
        public FileDto File { get; set; }
        public int? AssignmentId { get; set; }

    }
}