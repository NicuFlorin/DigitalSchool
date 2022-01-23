using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QuizSubmitDto
    {
        public int Id { get; set; }
        public DateTime DateSubmit { get; set; }
        public DateTime DateOpened { get; set; }
        public long TimeLeft { get; set; } = 0;
        public string Password { get; set; }
        public QuestionDto CurrentQuestion { get; set; }
    }
}