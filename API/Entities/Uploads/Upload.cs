using System;
using System.Collections.Generic;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Upload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfUpload { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Section Section { get; set; }
        public int? SectionId { get; set; }
        public ICollection<FileUpload> Files { get; set; }

        public string Discriminator { get; private set; }


    }
}