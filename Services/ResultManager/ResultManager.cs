using QuizChampion.Dtos;
using System;

namespace QuizChampion.Services.ResultManager;

public class ResultManager : IResultManager
{
    private List<UserScoreDto> _userScore;

    public ResultManager()
    {
        _userScore = new List<UserScoreDto>();
    }

    public void UpdateResult(UserAnswerDto answer)
    {
        bool retryAnser = _userScore.Any(x => x.QuestionId == answer.QuestionId);

        if (string.Equals(answer.UserAnswer.ToString(), answer.CorrectAnswer.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            if (retryAnser)
            {
                var score = _userScore.First(x => x.QuestionId == answer.QuestionId);
                score.Score = 0.5;

                Console.WriteLine("Correct");
                return;
            }

            UserScoreDto correct = new UserScoreDto
            {
                QuestionId = answer.QuestionId,
                Score = 1
            };
            _userScore.Add(correct);

            Console.WriteLine("Correct");
            return;
        }

        if (!retryAnser)
        {
            UserScoreDto wrong = new UserScoreDto
            {
                QuestionId = answer.QuestionId,
                Score = 0
            };
            _userScore.Add(wrong);
        }

        Console.WriteLine("Wrong");
    }

    public void ShowResult()
    {
        int questionCount = 1;

        foreach (var score in _userScore)
        {
            Console.WriteLine("Question #{0}: {1}", questionCount++, score.Score);
        }

        Console.WriteLine("Total: {0}", _userScore.Sum(x => x.Score));
    }

    public IEnumerable<Guid> QuestionToRetray()
    {
        return _userScore.Where(x => x.Score == 0).Select(x => x.QuestionId);
    }
}

