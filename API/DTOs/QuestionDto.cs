using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool hasMultipleAnswears { get; set; }
        public string shortAnswear { get; set; }

        public FileDto Image { get; set; }
        public int? ImageId { get; set; }
        public ICollection<ChoiceDto> Choices { get; set; }
        public int QuizId { get; set; }
    }
}