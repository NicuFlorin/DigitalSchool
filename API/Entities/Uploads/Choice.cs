using System.Collections.Generic;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isCorrect { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public ICollection<Answear> Answears { get; set; }
    }
}