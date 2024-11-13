using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using AppApi.Enities;
using AppApi.Data;
using AppApi.Models;
using Microsoft.EntityFrameworkCore;

using System;

using System.Text.Json.Serialization;
using AppApi.ChannelModels;
using AppApi.ViewModels;
using System.Globalization;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : ControllerBase
    {
        private readonly DataContext _cxt;
        private IWebHostEnvironment _webHostEnvironment;

        public InfluencerController( DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _cxt = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<InfluencerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ViewModels.InfluencerViewModel>? results = new List<ViewModels.InfluencerViewModel>();
            List<InfluencerModelView> viewResult = new List<InfluencerModelView>();

            var baseUri = $"{Request.Scheme}://{Request.Host}:{Request.Host.Port ?? 80}";
            var baseUri2 = $"{Request.Scheme}://{Request.Host}";

            var result = await _cxt.Influencer
                .Include(f => f.FaceBook)
                .Include(i => i.Instagram)
                .Include(y => y.YouTube)
                .Include(t => t.Twitter)
                .Include(m => m.MapData)
                .Include(c => c.CityMapData)
                .Select(x => new ViewModels.InfluencerViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = baseUri2 + x.Image,
                    IsFaceBook = x.IsFaceBook,
                    IsInstagram = x.IsInstagram,
                    IsTwitter = x.IsTwitter,
                    IsYouTube = x.IsYouTube,

                    YModel = x.YouTube == null ? null : new ViewModels.InfluencerViewModel.YouTubeModel
                    { Views = x.YouTube.Views, Subscribers = x.YouTube.Subscribers, IconImage = x.YouTube.IconImage },

                    IModel = x.Instagram == null ? null : new ViewModels.InfluencerViewModel.InstagramModel
                    {
                        Followers = x.Instagram.Followers,
                        AverageLikes = x.Instagram.AverageLikes,
                        EngagementRate = x.Instagram.EngagementRate,
                        IconImage = x.Instagram.IconImage
                    },

                    FModel = x.FaceBook == null ? null : new ViewModels.InfluencerViewModel.FaceBookModel
                    { Likes = x.FaceBook.Likes, TalkingAbout = x.FaceBook.TalkingAbout, IconImage = x.FaceBook.IconImage },

                    TModel = x.Twitter == null ? null : new ViewModels.InfluencerViewModel.TwitterModel
                    { Followers = x.Twitter.Followers, IconImage = x.Twitter.IconImage },

                    MMap = x.MapData == null ? null : x.MapData,
                    CMap = x.CityMapData == null ? null : x.CityMapData,
                }).ToListAsync();
            foreach (var r in result)
            {
               
                var f = r.FModel == null ? 0 : r.FModel.Likes;
                var t = r.TModel == null ? 0 : r.TModel.Followers;
                var i = r.IModel == null ? 0 : r.IModel.AverageLikes;
                var y = r.YModel == null ? 0 : r.YModel.Subscribers;
                r.Total = f + t + i + y;

                if (r.Total > 0)
                {
                    double d;
                    if (r.Total <= 1000)
                    {
                         d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,#", CultureInfo.InvariantCulture);
                    }
                    else if (r.Total >= 1000 && r.Total < 1000000)
                    {
                         d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,##0,k", CultureInfo.InvariantCulture);

                    }
                    else if (r.Total >= 1000000 && r.Total < 1000000000)
                    {
                         d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,##0,,M", CultureInfo.InvariantCulture);

                    }
                    else
                    {
                         d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,##0,,,B", CultureInfo.InvariantCulture);
                    }
                   
                    viewResult.Add(new InfluencerModelView { 
                        
                        Name = r.Name,
                        Image = r.Image,
                        IsFaceBook = r.IsFaceBook,
                        IsInstagram = r.IsInstagram,
                        IsTwitter = r.IsTwitter,
                        IsYouTube = r.IsYouTube,
                        Total = r.Total,
                        TotalStringValue = r.TotalStringValue,
                        countryMapData = r.MMap,
                        CMap = r.CMap
                    });  
                }
            }

            //=========================================fake data====================
            long? fakeTotal = 1000;
            List<InfluencerModelView> fakelist = new List<InfluencerModelView>();
            if (viewResult.Count != 30)
            {
                for (int i = 0; i < (30 - viewResult.Count); i++)
                {
                    fakeTotal = fakeTotal + (100 * (i + 1));

                    fakelist.Add(new InfluencerModelView
                    {
                        Name = "Influencer",
                        IsFaceBook = true,
                        IsInstagram = true,
                        IsTwitter = true,
                        IsYouTube = true,
                        Total = fakeTotal,
                        //Image = baseUri2 + "/imgs/nobg.webp",
                        Image = baseUri2 + "/imgs/tiwa-savage-nigeria.jpg",
                        CMap = viewResult.First().CMap,
                        countryMapData = viewResult.First().countryMapData,
                        

                    }
                    );
                }
                foreach (var r in fakelist)
                {
                    double d;
                    if (r.Total <= 1000)
                    {
                        d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,#", CultureInfo.InvariantCulture);
                    }
                    else if (r.Total >= 1000 && r.Total < 1000000)
                    {
                        d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,##0,k", CultureInfo.InvariantCulture);

                    }
                    else if (r.Total >= 1000000 && r.Total < 1000000000)
                    {
                        d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,##0,,M", CultureInfo.InvariantCulture);

                    }
                    else
                    {
                        d = (double)r.Total;
                        r.TotalStringValue = d.ToString("#,##0,,,B", CultureInfo.InvariantCulture);
                    }

                }
                viewResult.AddRange(fakelist);
            }

            viewResult = viewResult.OrderByDescending(x => x.Total).ToList();
            int secondRowStart = 1;
            int rank = 0;
            foreach (var item in viewResult)
            {
               
                rank = rank + 1;
                item.Rank = rank;
                if (item.Rank == 1)
                {
                    item.RowGroup = 1;
                    item.PositionInRow= 3;
                    item.ImageCssClass = "top-image";
                    item.NameCssClass = "top-name";
                    item.RankCssClass = "top-rank";
                    item.ContainerCssClass = "top-container";
                } 
                else if( item.Rank ==2  )
                {
                    item.RowGroup = 1;
                    item.PositionInRow = 4;
                    item.ImageCssClass = "top-2-image";
                    item.NameCssClass = "top-2-name";
                    item.RankCssClass = "top-2-rank";
                    item.ContainerCssClass = "top2-container";
                }
                else if (item.Rank == 3)
                {   
                    item.RowGroup = 1;
                    item.PositionInRow = 2;
                    item.ImageCssClass = "top-3-image";
                    item.NameCssClass = "top-3-name";
                    item.RankCssClass = "top-3-rank";
                    item.ContainerCssClass = "top3-container";
                }   
                else if (item.Rank == 4 )
                {
                    
                    item.RowGroup = 1;
                    item.PositionInRow = 1;
                    item.ImageCssClass = "top-4-image";
                    item.NameCssClass = "top-4-name";
                    item.RankCssClass = "top-4-rank";
                    item.ContainerCssClass = "top4-container";
                }
                else if (item.Rank == 5)
                {

                    item.RowGroup = 1;
                    item.PositionInRow = 5;
                    item.ImageCssClass = "top-5-image";
                    item.NameCssClass = "top-5-name";
                    item.RankCssClass = "top-5-rank";
                    item.ContainerCssClass = "top5-container";
                }
                
                else if ( item.Rank >= 6 && item.Rank < 13)
                {
                    item.RowGroup = 2;
                    item.PositionInRow = secondRowStart;
                    secondRowStart++;
                    if (item.Rank % 2 == 0 )
                    {
                        item.ImageCssClass = "top20even-image";
                        item.NameCssClass = "top20even-name";
                        item.RankCssClass = "top20even-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }
                    else
                    {
                        item.ImageCssClass = "top20odd-image";
                        item.NameCssClass = "top20old-name";
                        item.RankCssClass = "top20old-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }
                }
                else if (item.Rank >= 13 && item.Rank <= 24)
                {
                    item.RowGroup = 3;
                    if ( item.Rank == 13 )
                    {
                        item.PositionInRow = 2;
                    }else if ( item.Rank == 14 ) 
                    {
                        item.PositionInRow = 4;
                    }
                    else if (item.Rank == 15)
                    {
                        item.PositionInRow = 5;
                    }
                    else if (item.Rank == 16)
                    {
                        item.PositionInRow = 6;
                    }
                    else if (item.Rank == 17)
                    {
                        item.PositionInRow = 8;
                    }
                    else if (item.Rank == 18)
                    {
                        item.PositionInRow = 1;
                    }
                    else if (item.Rank == 19)
                    {
                        item.PositionInRow = 3;
                    }
                    else if (item.Rank == 20)
                    {
                        item.PositionInRow = 10;
                    }
                    else if (item.Rank == 21)
                    {
                        item.PositionInRow = 11;
                    }
                    
                else if (item.Rank == 22)
                {
                    item.PositionInRow = 12;
                }
                else if (item.Rank == 23)
                {
                    item.PositionInRow = 7;
                }
                else if (item.Rank == 24)
                {
                    item.PositionInRow = 9;
                }
                    

                    if (item.Rank % 2 == 0)
                    {
                        item.ImageCssClass = "top30even-image";
                        item.NameCssClass = "top30old-name";
                        item.RankCssClass = "top30old-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }
                    else
                    {
                        item.ImageCssClass = "top30odd-image";
                        item.NameCssClass = "top30old-name";
                        item.RankCssClass = "top30old-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }

                }
                else if(item.Rank > 24 )
                {


                    item.RowGroup = 4;
                    item.PositionInRow = 6;
                    item.ImageCssClass = "last-image";
                    item.NameCssClass = "last-name";
                    item.RankCssClass = "last-rank";
                    item.ContainerCssClass = "top" + item.Rank + "-container";

                }


            }

            viewResult = viewResult.OrderBy(x => x.RowGroup).ToList();

            return new JsonResult(viewResult);
        }

        // GET api/<InfluencerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InfluencerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InfluencerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InfluencerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
