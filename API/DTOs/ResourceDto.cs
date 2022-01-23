using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfUpload { get; set; }
        public int CourseId { get; set; }
        public int? SectionId { get; set; }
        public ICollection<IFormFile> ClientFiles { get; set; }
        public ICollection<FileDto> Files { get; set; }
    }
}