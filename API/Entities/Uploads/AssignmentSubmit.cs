using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.Uploads
{
    public class AssignmentSubmit : Submit
    {

        public string Text { get; set; }
        public string Feedback { get; set; }

        public double Grade { get; set; }

        public FileUpload File { get; set; }
        public int FileId { get; set; }
        public Assignment Assignment { get; set; }
        public int? AssignmentId { get; set; }

    }
}