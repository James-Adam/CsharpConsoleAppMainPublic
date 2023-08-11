namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<Worker> _logger;
    private readonly List<string> Urls = new() { "https://google.com" };

    public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await PollUrls();
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while polling urls");
            }
            finally
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }

    private async Task PollUrls()
    {
        List<Task> tasks = new();
        foreach (string url in Urls)
        {
            tasks.Add(PollUrl(url));
        }

        await Task.WhenAll(tasks);
    }

    private async Task PollUrl(string url)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("{Url} is online.", url);
            }
            else
            {
                _logger.LogWarning("{Url) is offline.", url);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "{Url) is offline.", url);
        }
    }
}