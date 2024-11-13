using System.ComponentModel.DataAnnotations;

namespace AppApi.Models
{
    public class InfluencerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TotalFollowers { get; set; }
        public string? Description1 { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ImgUrl { get; set; }
        public virtual List<string>? ChannelImageUrl { get; set; }
       

    }
}
