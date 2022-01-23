using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int CohortId { get; set; }
        public MemberDto MemberDto { get; set; }

    }
}