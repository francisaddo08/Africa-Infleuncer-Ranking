using System.Text.Json.Serialization;

namespace AppApi.ChannelModels
{
    public record class TwitterChannelModel(
         [property: JsonPropertyName("data")] TData Data
        )
    {

    }
    public record class TData(
        [property: JsonPropertyName("statistics")] TStatistics Statistics
        )
    {

    }
    public record class TStatistics([property: JsonPropertyName("total")] TTotal Total)
    {

    }
    public record class TTotal(
        [property: JsonPropertyName("followers")] Int64 Followers
        )
    {
    }
}
