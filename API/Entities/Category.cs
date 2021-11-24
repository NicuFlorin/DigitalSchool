using System.Collections.Generic;

namespace API.Entities
{
    public class Context
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Context Parent { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<Context> SubCategory { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Cohort> Cohorts { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }

    }
}