using AppApi.GeoLocation;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AppApi.ChannelModels
{
    public record class MapData(
        [property: JsonPropertyName("results")] AResult[] Result,
        [property: JsonPropertyName("status")] string status
        )
    {
    }

    public record class AResult
      (
        [ property: JsonPropertyName("address_components")] object[] AddressComponent,
        [property: JsonPropertyName("formatted_address")] string FomatedAddress,
        [property: JsonPropertyName("geometry")] AGeometry Geometry,
       [property: JsonPropertyName("place_id")] string PlaceId,
       [property: JsonPropertyName("types")] string[] Types
      )
    {

    }
  
    public record class AGeometry(
            [property: JsonPropertyName("bounds")] ABounds Bounds,
            [property: JsonPropertyName("location")] ALocations Locations,
             [ property: JsonProperty("location_type")] string LocationType,
            [property: JsonPropertyName("viewport")] AViewPort ViewPort

            )
    { }
    public record class ABounds(
       [property: JsonPropertyName("northeast")] Northeast Northeast,
       [property: JsonPropertyName("southwest")] Southwest Southwest
       )
    { }

    public record class ALocations(
        [property: JsonPropertyName("lat")] double lat,
        [property: JsonPropertyName("lng")] double Long

        )
    { }
    public record class AViewPort
        ([property: JsonPropertyName("northeast")] ANortheast NorthEast,
        [property: JsonPropertyName("southwest")] ASouthwest Southwest
        )
    { }

    public record class ANortheast
      (
       [property: JsonPropertyName("lat")] double Lat,
      [property: JsonPropertyName("lng")] double Long
      )
    {
    }
    public record class ASouthwest
        (
         [property: JsonPropertyName("lat")] double Lat,
        [property: JsonPropertyName("lng")] double Long
        )
    { }


}
