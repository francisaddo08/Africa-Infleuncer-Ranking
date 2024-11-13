using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppApi.Enities
{
    public class YouTube
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Influencer")]
        public int InfluencerId { get; set; }
        public Int64 Subscribers { get; set; }
        public Int64 Views { get; set; }
        public string? IconImage { get; set; }
    }
}