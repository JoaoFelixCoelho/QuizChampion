namespace QuizChampion.Dtos;

public class QuestionDto
{
    public Guid QuestionId { get; set; }
    public string Question { get; set; }
    public List<AnswerDto> Answers { get; set; }
}