namespace QuizChampion.Dtos;

public class UserScoreDto
{
    public Guid QuestionId { get; set; }
    public double Score { get; set; }
}