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

        public int SchoolId { get; set; }
        [Required]
        public int ContextId { get; set; }
    }
}