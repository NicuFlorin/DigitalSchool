using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CohortDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        [Required]
        public int ContextId { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string ContextName { get; set; }
    }
}