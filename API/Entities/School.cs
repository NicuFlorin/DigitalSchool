using System.Collections.Generic;

namespace API.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Context> Categories { get; set; }


    }
}