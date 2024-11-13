using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppApi.Enities
{
    public class FaceBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Influencer")]
        public int InfluencerId { get; set; }
        public Int64 Likes { get; set; }
        public Int64 TalkingAbout { get; set; }
        public string? IconImage { get; set; }

    }
}
