using QuizChampion.Dtos;

namespace QuizChampion.Services.ResultManager;

public interface IResultManager
{
    void UpdateResult(UserAnswerDto answer);
    void ShowResult();
    IEnumerable<Guid> QuestionToRetray();
}

