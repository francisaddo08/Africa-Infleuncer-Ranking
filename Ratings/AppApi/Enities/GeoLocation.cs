using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppApi.Enities
{
    public class GeoLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Influencer")]
        public int InfluencerId { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? CountryCode { get; set; }
        public string? State { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? MetroArea { get; set; }

        public string? PostCode { get; set; }



    }
}
