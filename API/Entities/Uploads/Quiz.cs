using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Quiz : Upload
    {
        public DateTime OpenQuiz { get; set; }
        public DateTime CloseQuiz { get; set; }
        public int TimeLimit { get; set; }
        public double MaximumGrade { get; set; }
        public double GradeToPass { get; set; }
        public bool ShuffleActivated { get; set; }
        public string Password { get; set; }
        public ICollection<Question> Questions { get; set; }
        public bool AllowGoingBack { get; set; } = false;
        public ICollection<QuizSubmit> QuizSubmits { get; set; }
    }
}