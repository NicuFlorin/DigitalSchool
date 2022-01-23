namespace API.Entities.Uploads
{
    public class Answear
    {
       public int Id { get; set; }
       public Choice Choice { get; set; }
       public int ChoiceId { get; set; }
       public QuestionAnswear QuestionAnswear { get; set; }
       public int QuestionAnswearId { get; set; }
    }
}