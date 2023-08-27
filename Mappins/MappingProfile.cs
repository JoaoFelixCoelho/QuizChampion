using AutoMapper;
using QuizChampion.Dtos;
using QuizChampion.Models;

namespace QuizChampion.Mappins;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Question, QuestionDto>()
            .ConvertUsing(src => MapQuestion(src));
    }

    private QuestionDto MapQuestion(Question source)
    {
        var question = new QuestionDto();
        question.QuestionId = Guid.NewGuid();
        question.Question = source.question;

        var answers = new List<AnswerDto>();
        answers.Add(new AnswerDto
        {
            Answer = source.correct_answer,
            Correct = true
        });
        answers.AddRange(source.incorrect_answers.Select(x => new AnswerDto
        {
            Answer = x,
            Correct = false,
        }));

        question.Answers = answers;
        return question;
    }
}

