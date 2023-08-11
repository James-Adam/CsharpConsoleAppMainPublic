using FinanceNewsTicker.Models;
using FinanceNewsTicker.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceNewsTicker.Pages;

public class IndexModel : PageModel
{
    //reference
    private readonly ILogger<IndexModel> _logger;

    private readonly INewsService _newsService;
    public FinanceNews news;

    public IndexModel(ILogger<IndexModel> logger,
        INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    public void OnGet()
    {
        news = _newsService.GetFinanceNews(0); //no offset
    }

    public void OnGetLoadMoreNews(int offset)
    {
        news = _newsService.GetFinanceNews(offset);
    }
}