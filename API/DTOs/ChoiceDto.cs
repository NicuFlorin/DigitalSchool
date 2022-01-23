namespace API.DTOs
{
    public class ChoiceDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}