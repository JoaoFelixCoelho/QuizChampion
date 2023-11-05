using AutoMapper;
using QuizChampion.Dtos;
using QuizChampion.Extensions;
using QuizChampion.Models;

namespace QuizChampion.Services.QuestionManager;

public class QuestionManager : IQuestionManager
{
    private readonly IMapper _mapper;

    public QuestionManager(IMapper mapper)
    {
        _mapper = mapper;
    }

    //Teste

    public async Task<IEnumerable<QuestionDto>> GetQuestionsForQuizz(int questionsToStart, IEnumerable<Question> allQuestions)
    {
        var randomQuestions = GenericUtil.RandomizeCollection(allQuestions).Take(questionsToStart);
        
        var questions = _mapper.Map<IEnumerable<QuestionDto>>(randomQuestions).ToList();
        char option = 'A';

        foreach (var ques in questions)
        {
            ques.Answers = GenericUtil.RandomizeCollection(ques.Answers).ToList();

            foreach (var ans in ques.Answers)
            {
                ans.Option = option++;
            }

            option = 'A';
        }

        return questions;
    }
}

