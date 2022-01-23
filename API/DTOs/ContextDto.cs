using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ContextDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public List<ContextDto> SubCategory { get; set; }
    
    }
}