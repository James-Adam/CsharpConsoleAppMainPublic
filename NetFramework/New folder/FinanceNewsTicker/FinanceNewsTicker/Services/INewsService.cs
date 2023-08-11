using FinanceNewsTicker.Models;

namespace FinanceNewsTicker.Services;

public interface INewsService
{
    //Method
    FinanceNews GetFinanceNews(int offset);
}