using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AppApi.ChannelModels
{
    public record class FaceBookChannelModel(
         [property: JsonPropertyName("data")] FData Data
        )
    {

    }
    public record class FData(
        [property: JsonPropertyName("statistics")] FStatistics Statistics
        )
    {

    }
    public record class FStatistics([property: JsonPropertyName("total")] FTotal Total)
    {

    }
    public record class FTotal(
        [property: JsonPropertyName("likes")] long Likes,
        [property: JsonPropertyName("talking_about")] long TalkingAbout
        )
    {


    }
}
