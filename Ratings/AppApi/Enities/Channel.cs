using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AppApi.Enities
{
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("InfluencerDetail")]
        public int InfluencerDetailId { get; set; }
        public string? Name { get; set; }
        public int? Followers { get; set; }
        public int? Subcribers { get; set; }
        public int? Views { get; set; }    
        public string? ImageUrl { get; set; }
         

    }
}
