using System.Collections.Generic;
using API.Entities.Uploads;

namespace API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public double Mark { get; set; } = 1.0;
        public bool hasMultipleAnswears { get; set; }
        public string shortAnswear { get; set; }
        public double WrongAnswearSanction { get; set; } = 0;
        public FileUpload Image { get; set; }
        public int? ImageId { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
    }
}