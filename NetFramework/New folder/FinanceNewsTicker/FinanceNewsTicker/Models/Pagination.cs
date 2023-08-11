using Newtonsoft.Json;

namespace FinanceNewsTicker.Models;

public class Pagination
{
    [JsonProperty("limit")] public int Limit { get; set; }

    [JsonProperty("offset")] public int Offset { get; set; }

    [JsonProperty("count")] public int Count { get; set; }

    [JsonProperty("total")] public int Total { get; set; }
}