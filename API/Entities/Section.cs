using System;
using System.Collections.Generic;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Upload> Uploads { get; set; }
        
        // public ICollection<Folder> Folders { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public DateTime? WeekStart { get; set; }
        public DateTime? WeekEnd { get; set; }
    }
}