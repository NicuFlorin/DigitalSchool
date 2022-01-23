using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.Uploads
{
    public class QuizSubmit : Submit
    {

        public double FinalGrade { get; set; }
        public DateTime DateSubmit { get; set; }
        public DateTime DateOpened { get; set; }
        public int IndexCurrentQuestion { get; set; } = 0;
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public ICollection<QuestionAnswear> Answears { get; set; }

    }
}