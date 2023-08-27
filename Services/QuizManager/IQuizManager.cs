using QuizChampion.Dtos;

namespace QuizChampion.Services.QuizManager;

public interface IQuizManager
{
    Task<IEnumerable<QuestionDto>> StartQuizAsync(int questionsToStart);
}

