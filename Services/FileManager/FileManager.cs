using Newtonsoft.Json;
using QuizChampion.Models;
using System.Net.Http;
using System.Text.Json;

namespace QuizChampion.Services.FileManager;

public class FileManager : IFileManager
{
    private readonly IHttpClientFactory _httpClientFactory;
    private string _endPoint = "https://opentdb.com/api.php?amount=10&category=18&difficulty=medium&type=multiple";
    private string _filePath = "C:\\Repo\\QuizChampion\\Questions.json";

    public FileManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Question>> GetFileQuestions()
    {
        var client = _httpClientFactory.CreateClient();
        var httprequest = new HttpRequestMessage(HttpMethod.Get, _endPoint);
        var response = await client.SendAsync(httprequest, CancellationToken.None);

        response.EnsureSuccessStatusCode();

        var result = response.Content.ReadAsStringAsync().Result;
        var items = System.Text.Json.JsonSerializer.Deserialize<Questions>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return items.results;

        //using (StreamReader r = new StreamReader(_filePath))
        //{
        //    string json = r.ReadToEnd();
        //    Questions items = JsonConvert.DeserializeObject<Questions>(json);
        //    return items.results;
        //}
    }
}

