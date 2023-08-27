namespace QuizChampion.Dtos;

public class UserAnswerDto
{
    public Guid QuestionId { get; set; }
    public char UserAnswer { get; set; }
    public char CorrectAnswer { get; set; }
}