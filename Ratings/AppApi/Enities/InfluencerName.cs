using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AppApi.Enities
{
    public class InfluencerName
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public string?     Country { get; set; }
        public string? PlaceId { get; set; }
        public Int64? NortheastLatitude { get; set; }
        public Int64? NortheastLongitude { get; set; }
        public Int64? SouthwestLatitude { get; set; }
        public Int64? SouthwestLongitude { get; set; }
        public Int64? VPNELat { get; set; }
        public Int64? VPNELog { get; set; }
        public Int64? VPSWLat { get; set; }
        public Int64? VPSWLog { get; set; }
        public virtual FaceBook? FaceBook { get; set; }

    }
}
