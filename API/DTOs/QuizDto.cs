using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QuizDto : UploadDto
    {
         public DateTime OpenQuiz { get; set; }
        public DateTime CloseQuiz { get; set; }
        public int TimeLimit { get; set; }
        public decimal MaximumGrade { get; set; }
        public decimal GradeToPass { get; set; }
        public bool ShuffleActivated { get; set; }
        public string Password { get; set; }
        public ICollection<QuestionDto> Questions { get; set; }
    }
}