using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AppApi.ChannelModels
{
    public record class InstagramChannelModel(
        [property: JsonPropertyName("data")] IData Data)
    {
       
    }
    public record class IData(
         [property: JsonPropertyName("statistics")] IStatistics Statistics
         )
    {

    }
    public record class IStatistics(
        [property: JsonPropertyName("total")] ITotal Total,
        [property: JsonPropertyName("average")] IAverage Average
        
        )
    {

    }

    public record class ITotal(
        [property: JsonPropertyName("media")] Int64 Media,
        [property: JsonPropertyName("followers")] Int64 Followers,
         [property: JsonPropertyName("following")] Int64 Following,
        [property: JsonPropertyName("engagement_rate")] double EngagementRate
        )
    {


    }
    public record class IAverage
        (
         [property : JsonPropertyName("likes")] Int64 Likes,
        [property: JsonPropertyName("comments")] double Comments

        )
    {

    }
}
