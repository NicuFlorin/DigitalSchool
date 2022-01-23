using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UploadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discriminator { get; set; }
        public int CourseId { get; set; }
        public int? SectionId { get; set; }

        public ICollection<FileDto> Files { get; set; }
   


    }
}