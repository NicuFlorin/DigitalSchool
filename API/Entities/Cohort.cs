using System.Collections.Generic;

namespace API.Entities
{
    public class Cohort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentEnrollment> Students { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Context Context { get; set; }
        public int ContextId { get; set; }
        public string Description { get; set; }
    }
}