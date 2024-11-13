using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppApi.Enities
{
    public class InfluencerDetail
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("InfluencerName")]
        public int InfluencerNameID { get; set; }

        public int TotalFollowers { get; set; }
        public int Rank { get; set; }
        
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        
        public string? Country { get; set; }
        
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Region { get; set; }
        public string? GeoLocationID { get; set; }
        public string? MetroArea { get; set; }
        public string? PostCode { get; set; }
        public string? ImgUrl { get; set; }
        public virtual ICollection<Channel>? Channels { get; set; }
        

    }
}
