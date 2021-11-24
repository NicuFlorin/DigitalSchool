using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int schoolId { get; set; } = -1;

        public IEnumerable<string> Roles { get; set; } = new string[]{"Member"};
    }
}