using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AppApi.ChannelModels
{
    public record class YouTubeChannelModel(
         [property: JsonPropertyName("data")] YData Data
        )
    { }
    public record class YData(
    [property: JsonPropertyName("statistics")] YStatistics Statistics
    )
    {

    }
    public record class YStatistics([property: JsonPropertyName("total")] YTotal Total)
    {

    }
}
public record class YTotal(
    [property: JsonPropertyName("subscribers")] long Subscribers,
    [property: JsonPropertyName("views")] long Views
    )
{


}

