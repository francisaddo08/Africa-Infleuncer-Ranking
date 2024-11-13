using AppApi.ChannelModels;
using AppApi.Enities;

namespace AppApi.ViewModels
{
    public class InfluencerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsFaceBook { get; set; }
        public bool IsYouTube { get; set; }
        public bool? IsInstagram { get; set; }
        public bool IsTwitter { get; set; }
        public string? Image { get; set; }

        public  CountryMapData? MMap { get; set; }
        public CityMapData? CMap{get; set;}
        public FaceBookModel? FModel { get; set; }
        public InstagramModel? IModel { get; set; }
        public YouTubeModel? YModel { get; set; }
        public TwitterModel? TModel { get; set; }

        
        public Int64? Total { get; set; }
        public string? TotalStringValue { get; set; }



        public class FaceBookModel
        {
            public Int64 Likes { get; set; }
            public Int64 TalkingAbout { get; set; }
            public string? IconImage { get; set; }
        }

        public class InstagramModel
        {
            public Int64? Followers { get; set; }
            public double? EngagementRate { get; set; }
            public Int64? AverageLikes { get; set; }
            public string? IconImage { get; set; }
        }

        public class YouTubeModel
        {
            public Int64 Subscribers { get; set; }
            public Int64 Views { get; set; }
            public string? IconImage { get; set; }
        }

        public class TwitterModel
        {
            public Int64? Followers { get; set; }
            public string? IconImage { get; set; }
        }
    }
}
