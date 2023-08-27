// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using QuizChampion.Dtos;
using QuizChampion.Mappins;
using QuizChampion.Services.FileManager;
using QuizChampion.Services.QuestionManager;
using QuizChampion.Services.QuizManager;
using QuizChampion.Services.ResultManager;

var serviceProvider = new ServiceCollection()
                .AddAutoMapper(x => x.AddProfile<MappingProfile>())
                .AddHttpClient()
                .AddScoped<IFileManager, FileManager>()
                .AddScoped<IQuestionManager, QuestionManager>()
                .AddScoped<IQuizManager, QuizManager>()
                .AddScoped<IResultManager, ResultManager>()
                .BuildServiceProvider();

var _quiz = serviceProvider.GetRequiredService<IQuizManager>();
var _result = serviceProvider.GetRequiredService<IResultManager>();
var quizQuestions = await _quiz.StartQuizAsync(3);

foreach (var qq in quizQuestions)
{
    Console.WriteLine(qq.Question);

    foreach (var ans in qq.Answers)
    {
        Console.WriteLine(ans.Option + " - " + ans.Answer);
    }

    Console.WriteLine("");
    Console.WriteLine("Your answer:");
    var userAnswer = Console.ReadLine();

    Console.WriteLine("");
    _result.UpdateResult(new UserAnswerDto() { QuestionId = qq.QuestionId, UserAnswer = userAnswer[0], CorrectAnswer = qq.Answers.First(x => x.Correct).Option });

    Console.WriteLine("");
    Console.WriteLine("Press any key...");
    Console.ReadLine();

    Console.Clear();
}

Console.Clear();

_result.ShowResult();

Console.WriteLine("");
Console.WriteLine("Press any key...");
Console.ReadLine();
Console.Clear();

foreach (var qq in quizQuestions.Where(x => _result.QuestionToRetray().Contains(x.QuestionId)))
{
    Console.WriteLine(qq.Question);

    foreach (var ans in qq.Answers)
    {
        Console.WriteLine(ans.Option + " - " + ans.Answer);
    }

    Console.WriteLine("");
    Console.WriteLine("Your answer:");
    var userAnswer = Console.ReadLine();

    Console.WriteLine("");
    _result.UpdateResult(new UserAnswerDto() { QuestionId = qq.QuestionId, UserAnswer = userAnswer[0], CorrectAnswer = qq.Answers.First(x => x.Correct).Option });

    Console.WriteLine("");
    Console.WriteLine("Press any key...");
    Console.ReadLine();

    Console.Clear();
}

Console.Clear();

_result.ShowResult();

Console.WriteLine("");
Console.WriteLine("Press any key...");
Console.ReadLine();
Console.Clear();
