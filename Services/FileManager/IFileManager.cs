using QuizChampion.Models;

namespace QuizChampion.Services.FileManager;

public interface IFileManager
{
    Task<IEnumerable<Question>> GetFileQuestions();
}


