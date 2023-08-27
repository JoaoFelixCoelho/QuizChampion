using QuizChampion.Dtos;
using QuizChampion.Services.FileManager;
using QuizChampion.Services.QuestionManager;

namespace QuizChampion.Services.QuizManager;

public class QuizManager : IQuizManager
{
    private readonly IFileManager _fileManager;
    private readonly IQuestionManager _questionsManager;

    public QuizManager(IFileManager fileManager, IQuestionManager questionsManager)
    {
        _fileManager = fileManager;
        _questionsManager = questionsManager;
    }

    public async Task<IEnumerable<QuestionDto>> StartQuizAsync(int questionsToStart)
    {
        var allQuestions = await _fileManager.GetFileQuestions();
        var gameQuestions = await _questionsManager.GetQuestionsForQuizz(questionsToStart, allQuestions);
        return gameQuestions;
    }
}

