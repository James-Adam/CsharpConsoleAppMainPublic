using FinanceNewsTicker.Models;
using Newtonsoft.Json;

namespace FinanceNewsTicker.Services;

public class NewsService : INewsService
{
    //dependency injection
    private readonly IConfiguration _configuration;

    //constructor
    public NewsService(IConfiguration configuration) //DI
    {
        _configuration = configuration; //DI
    }

    public FinanceNews GetFinanceNews(int offset)
    {
        var apiKey = _configuration.GetValue<string>("API_KEY");
        var baseUrl = _configuration.GetValue<string>("API_URL");

        //HttpClient request to API

        using HttpClient client = new();
        client.BaseAddress = new Uri(baseUrl!);

        var parameters =
            string.Format("?apikey={0}&offset={1}&date={2}&sort={3}", apiKey, offset, "today", "desc");

        //HTTP response
        var response = client.GetAsync(parameters).Result;

        //check to see if response works
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<FinanceNews>(result);
        }

        return new FinanceNews
        {
            Data = new List<NewsArticle>(),
            Pagination = new Pagination()
        };
    }
}