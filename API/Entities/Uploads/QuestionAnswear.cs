using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.Uploads
{
    public class QuestionAnswear
    {
        public int Id { get; set; }
        public QuizSubmit QuizSubmit { get; set; }
        public int QuizSubmitId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public string ShortAnswear { get; set; }
        public ICollection<Answear> Answears { get; set; }
        public int AnswearId { get; set; }
    }
}