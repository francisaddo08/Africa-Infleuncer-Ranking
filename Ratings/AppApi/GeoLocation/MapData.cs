using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace AppApi.GeoLocation
{
    public record class MapData
        ([property: JsonPropertyName("results")] Result Result)
    {
    }
    public record class Result
        ([property: JsonPropertyName("geometry")] Geometry Geometry,
         [property: JsonPropertyName("place_id")] string PlaceId
        )
    {

    }
    public record class Geometry(
        [property: JsonPropertyName("bounds")] Bounds Bounds,
        [property: JsonPropertyName("location")] Locations Locations,
        [property: JsonPropertyName("viewport")] ViewPort ViewPort

        )
    { }
    public record class Bounds(
        [property: JsonPropertyName("northeast")] Northeast Northeast, 
        [property: JsonPropertyName("southwest")] Southwest Southwest
        ) 
    { }
  
    public record class Locations(
        [property: JsonPropertyName("lat")] double lat,
        [property: JsonPropertyName("lng")] double Long

        ) { }
    public record class ViewPort
        ([property: JsonPropertyName("northeast")] Northeast NorthEast,
        [property : JsonPropertyName("southwest")] Southwest Southwest
        )
    { }

    public record class Northeast
      (
       [property: JsonPropertyName("lat")] double Lat,
      [property: JsonPropertyName("lng")] double Long
      )
    {
    }
    public record class Southwest
        (
         [property: JsonPropertyName("lat")] double Lat,
        [property: JsonPropertyName("lng")] double Long
        )
    { }

}
