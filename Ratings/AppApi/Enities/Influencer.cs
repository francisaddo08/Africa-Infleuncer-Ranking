using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppApi.Enities
{
    public class Influencer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool  IsFaceBook { get; set; }
        public bool IsYouTube  { get; set; }
        public  bool? IsInstagram { get; set; }
        public bool IsTwitter { get; set; }
        public string? Image { get; set; }

        public virtual CountryMapData? MapData { get; set; }
        public virtual CityMapData? CityMapData { get; set; }

        public virtual FaceBook? FaceBook { get; set; }
        public virtual YouTube? YouTube { get; set; }
        public virtual Instagram? Instagram { get; set; }
        public virtual Twitter? Twitter { get; set; }    
    }
}
