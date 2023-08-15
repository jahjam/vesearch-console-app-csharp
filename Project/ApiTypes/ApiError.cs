namespace ConsoleApp1.ApiTypes;

using Newtonsoft.Json;

public class ApiError
{
    public static ApiError? FromJson(string json)
    {
        return JsonConvert.DeserializeObject<ApiError>(json);
    }

    [JsonProperty("status")] public required string Status { get; set; }
    [JsonProperty("message")] public required string Message { get; set; }
}