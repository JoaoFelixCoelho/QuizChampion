using QuizChampion.Dtos;
using QuizChampion.Models;

namespace QuizChampion.Services.QuestionManager;

public  interface IQuestionManager
{
    Task<IEnumerable<QuestionDto>> GetQuestionsForQuizz(int questionsToStart, IEnumerable<Question> allQuestions);
}

