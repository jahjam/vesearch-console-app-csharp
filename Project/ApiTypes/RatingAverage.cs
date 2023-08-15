namespace ConsoleApp1.ApiTypes;

using Newtonsoft.Json;

public class RatingAverage
{
    public static RatingAverage? FromJson(string json) =>
        JsonConvert.DeserializeObject<RatingAverage>(json);

    [JsonProperty("status")] public required string Status { get; set; }

    [JsonProperty("data")] public required RatingAverageData Data { get; set; }
}

public class RatingAverageData
{
    [JsonProperty("ratings")] public required Rating[] Ratings { get; set; }
}

public class Rating
{
    [JsonProperty("avgRatings")] public int AvgRatings { get; set; }
}