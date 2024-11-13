using AppApi.ChannelModels;
using AppApi.Data;
using AppApi.Enities;
using AppApi.Models;
using IronXL;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace AppApi
{
    public class ExternalApiWorker : BackgroundService
    {

        private readonly ILogger<ExternalApiWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ExternalApiModel> _options;

        public ExternalApiWorker(
            IServiceScopeFactory serviceScopeFactory,
            IWebHostEnvironment webHostEnvironment,
            ILogger<ExternalApiWorker> logger,
            IConfiguration configuration,
            IOptions<ExternalApiModel> options
            )
        {
            _scopeFactory = serviceScopeFactory;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _options = options;
        }
        protected override async Task<Task> ExecuteAsync(CancellationToken stoppingToken)
        {
           

            //await FaceBookData();
            //await GetMapData();
            //await Instagram();
            //await YoutubeData();
            //await Twitter();
            return  Task.CompletedTask;
        }

        private async Task Twitter()
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _cxt = scope.ServiceProvider.GetRequiredService<DataContext>();

                    //var listFilter = new List<string>() { "United Kingdom", "United States" };
                    //var all = _cxt.Influencer.Where(x => listFilter.Contains(x.Country.Trim()))
                    //    .Select(x => new InFluencerFilter {Id = x.Id, Name = x.Name, Country = x.Country }).Take(3).ToList(); 
                    var fnamesIds = _cxt.FaceBook.Select(x => x.InfluencerId).ToList();
                   
                    var all = _cxt.Influencer
                        .Where(x => fnamesIds.Contains(x.Id))
                        .Where(x => x.IsTwitter !=false)
                        .Select(x => new { Id = x.Id, Name = x.Name, Country = x.Country }).ToList();

                    List<Twitter> list = new List<Twitter>();

                    //List<InFluencerFilter> filtered = new List<InFluencerFilter>();
                    //var Ids = _cxt.FaceBook.Select(x => x.InfluencerId).Distinct().ToList();
                    //foreach (var n in all)
                    //{
                    //    if (!Ids.Contains(n.Id))
                    //    {
                    //        filtered.Add(n);
                    //    }
                    //}


                    foreach (var n in all)
                    {


                    
                        string url = this._options.Value.TwitterUrl + n.Name + "&clientid=" + this._options.Value.SocialBladeClientId + "&token=" + this._options.Value.SocialBladeToken;
                        using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                        {
                            client.BaseAddress = new Uri(url);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new
                            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            var json = await client.GetStringAsync(url);

                            var results = JsonConvert.DeserializeObject<TwitterChannelModel>(json);
                            if (results != null)
                            {
                                var entity = new AppApi.Enities.Twitter
                                {
                                    InfluencerId = n.Id,
                                    Followers = results.Data.Statistics.Total.Followers
                                };
                                list.Add(entity);
                            }
                        }
                    }
                    await _cxt.Twitter.AddRangeAsync(list);


                    var t = await _cxt.SaveChangesAsync();
                    _logger.LogInformation("data saved" + " " + t);
                }

            }
            catch (Exception e)
            {

            }

        }


        private async Task YoutubeData()
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _cxt = scope.ServiceProvider.GetRequiredService<DataContext>();
                    var fnamesIds = _cxt.FaceBook.Select(x => x.InfluencerId).ToList();
                    var all = _cxt.Influencer
                        .Where(x =>fnamesIds.Contains(x.Id) )

                        .Select(x => new { Id = x.Id, Name = x.Name}).ToList();

                    List<YouTube> list = new List<YouTube>();
                    foreach (var n in all)
                    {
                        string url = this._options.Value.YouTubeUrl + n.Name + "&clientid=" + this._options.Value.SocialBladeClientId + "&token=" + this._options.Value.SocialBladeToken;
                        using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                        {
                            client.BaseAddress = new Uri(url);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new
                      System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            var json = await client.GetStringAsync(url);
                            var results = JsonConvert.DeserializeObject<YouTubeChannelModel>(json);
                            if (results != null)
                            {
                                var entity = new AppApi.Enities.YouTube
                                {
                                    InfluencerId = n.Id,
                                    Subscribers = results.Data.Statistics.Total.Subscribers,
                                    Views = results.Data.Statistics.Total.Views
                                };
                                list.Add(entity);
                            }
                        }
                    }
                    await _cxt.YouTube.AddRangeAsync(list);
                    var t = await _cxt.SaveChangesAsync();
                    _logger.LogInformation("data saved" + " " + t);
                }

            }
            catch (Exception e)
            {

            }

        }


      
        private async Task FaceBookData()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _cxt = scope.ServiceProvider.GetRequiredService<DataContext>();

                var all = _cxt.Influencer
                    .Select(x => new InFluencerFilter { Id = x.Id, Name = x.Name, Country = x.Country }).ToList();
                List<FaceBook> facebookList = new List<FaceBook>();

                

                foreach (var n in all)
                {
                    string facebookRequestUrl = this._options.Value.FacebookUrl + n.Name + "&clientid=" + this._options.Value.SocialBladeClientId + "&token=" + this._options.Value.SocialBladeToken;
                    using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                    {
                        client.BaseAddress = new Uri(facebookRequestUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new
                        System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        await using Stream stream =
                        await client.GetStreamAsync(facebookRequestUrl);
                        var results = await System.Text.Json.JsonSerializer.DeserializeAsync<FaceBookChannelModel>(stream);
                        if (results != null)
                        {
                            var faceBook = new AppApi.Enities.FaceBook
                            {

                                InfluencerId = n.Id,
                                Likes = results.Data.Statistics.Total.Likes,
                                TalkingAbout = results.Data.Statistics.Total.TalkingAbout
                            };
                            facebookList.Add(faceBook);
                        }

                    }


                }
                await _cxt.FaceBook.AddRangeAsync(facebookList);


                var t = await _cxt.SaveChangesAsync();
                _logger.LogInformation("data saved" + " " + t);
            }


        }

        private async Task Instagram()
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _cxt = scope.ServiceProvider.GetRequiredService<DataContext>();
                    var all = _cxt.Influencer
                        .Select(x => new { Id = x.Id, Name = x.Name, Country = x.Country }).Take(3).ToList();
                    List<Instagram> instagramList = new List<Instagram>();

                    foreach (var n in all)
                    {
                        string url = this._options.Value.InstagramUrl + n.Name + "&clientid=" + this._options.Value.SocialBladeClientId + "&token=" + this._options.Value.SocialBladeToken;
                        using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                        {
                            client.BaseAddress = new Uri(url);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new
                            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            var json = await client.GetStringAsync(url);

                            var results = JsonConvert.DeserializeObject<InstagramChannelModel>(json);
                            if (results != null)
                            {
                                var instagram = new AppApi.Enities.Instagram
                                {

                                    InfluencerId = n.Id,
                                    Followers = results.Data.Statistics.Total.Followers,
                                    EngagementRate = results.Data.Statistics.Total.EngagementRate,
                                    AverageComments = results.Data.Statistics.Average.Comments,
                                    AverageLikes = results.Data.Statistics.Average.Likes


                                };
                                instagramList.Add(instagram);
                            }
                        }
                    }
                    await _cxt.Instagram.AddRangeAsync(instagramList);
                    var t = await _cxt.SaveChangesAsync();
                    _logger.LogInformation("data saved" + " " + t);
                }

            }
            catch (Exception e)
            {

            }


        }

        private async Task GetMapData()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                //get the db
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                var all = db.Influencer.Select(x => x.Id).Distinct().ToList();
                var locations = db.Country.Select(x => x.InfluencerId).Distinct().ToList();
                var cityLocation = db.City
                    .Select(x => x.InfluencerId).Distinct().ToList();

                if (!(all.Count == cityLocation.Count))
                {
                    List<int> ids = new List<int>();
                    List<CityMapData> listData = new List<CityMapData>();
                    if (all.Any())
                    {
                        foreach (var id in all)
                        {
                            foreach (var lid in cityLocation)
                            {
                                if (id != lid)
                                {
                                    ids.Add(id);
                                }
                            }
                        }
                    }
                    if (ids.Count > 0)
                    {
                        var result = db.Influencer.Where(x => ids.Contains(x.Id))
                            .Select(x => new InFluencerFilter { Id = x.Id, Name = x.Name, City = x.City, Country = x.Country }).ToList();

                        foreach (var c in result)
                        {
                            var url = this._options.Value.GoogleUrl + c + this._options.Value.AndKey + this._options.Value.Key;
                            using (System.Net.Http.HttpClient client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(url);
                                client.DefaultRequestHeaders.Accept.Clear();
                                client.DefaultRequestHeaders.Accept
                                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                                await using Stream stream = await client.GetStreamAsync(url);
                                var maps = await System.Text.Json.JsonSerializer.DeserializeAsync<GeoLocation.MapData>(stream);
                                if (maps != null)
                                {
                                    var entity = new AppApi.Enities.CityMapData()
                                    {

                                        InfluencerId = c.Id,
                                        PlaceId = maps.Result.PlaceId,
                                        BoundsNELat = maps.Result.Geometry.Bounds.Northeast.Lat,
                                        BoundsNELong = maps.Result.Geometry.Bounds.Northeast.Long,
                                        BoundsSWLat = maps.Result.Geometry.Bounds.Southwest.Lat,
                                        BoundSWLong = maps.Result.Geometry.Bounds.Southwest.Long,
                                        ViewPortNELat = maps.Result.Geometry.ViewPort.NorthEast.Lat,
                                        ViewPortNELong = maps.Result.Geometry.ViewPort.NorthEast.Long,
                                        ViewPortSWLat = maps.Result.Geometry.ViewPort.Southwest.Lat,
                                        ViewPortSWLong = maps.Result.Geometry.ViewPort.Southwest.Long,
                                        LocationLat = maps.Result.Geometry.Locations.lat,
                                        LocationLong = maps.Result.Geometry.Locations.Long
                                    };
                                    listData.Add(entity);
                                }

                            }


                        }
                        await db.City.AddRangeAsync(listData);


                        var t = await db.SaveChangesAsync();
                        _logger.LogInformation("data saved" + " " + t);

                    }
                    else
                    {
                        var result = db.Influencer
                                                .Select(x => new InFluencerFilter { Id = x.Id, Name = x.Name, Country = x.Country }).ToList();

                        foreach (var c in result)
                        {
                            var url = this._options.Value.GoogleUrl + c + this._options.Value.AndKey + this._options.Value.Key;
                            using (System.Net.Http.HttpClient client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(url);
                                client.DefaultRequestHeaders.Accept.Clear();
                                client.DefaultRequestHeaders.Accept
                                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                               
                                await using Stream stream = await client.GetStreamAsync(url);
                                var maps = await System.Text.Json.JsonSerializer.DeserializeAsync<ChannelModels.MapData>(stream);
                                if (maps != null)
                                {
                                    var entity = new AppApi.Enities.CityMapData()
                                    {

                                        InfluencerId = c.Id,
                                        PlaceId = maps.Result[0].PlaceId,
                                        BoundsNELat = maps.Result[0].Geometry.Bounds.Northeast.Lat,
                                        BoundsNELong = maps.Result[0].Geometry.Bounds.Northeast.Long,
                                        BoundsSWLat = maps.Result[0].Geometry.Bounds.Southwest.Lat,
                                        BoundSWLong = maps.Result[0].Geometry.Bounds.Southwest.Long,
                                        ViewPortNELat = maps.Result[0].Geometry.ViewPort.NorthEast.Lat,
                                        ViewPortNELong = maps.Result[0].Geometry.ViewPort.NorthEast.Long,
                                        ViewPortSWLat = maps.Result[0].Geometry.ViewPort.Southwest.Lat,
                                        ViewPortSWLong = maps.Result[0].Geometry.ViewPort.Southwest.Long,
                                        LocationLat = maps.Result[0].Geometry.Locations.lat,
                                        LocationLong = maps.Result[0].Geometry.Locations.Long
                                    };
                            listData.Add(entity);
                        }
                    }
                        }
                        await db.City.AddRangeAsync(listData);
                        var t = await db.SaveChangesAsync();
                        _logger.LogInformation("data saved" + " " + t);
                    }
                }
                if (!(all.Count == locations.Count))
                {
                    List<int> ids = new List<int>();
                    List<int> cityids = new List<int>();

                    List<CountryMapData> maplist = new List<CountryMapData>();
                    if (all.Any())
                    {
                        foreach (var id in all)
                        {
                            foreach (var lid in locations)
                            {
                                if (id != lid)
                                {
                                    ids.Add(id);
                                }
                            }
                        }
                    }
                    if (ids.Count > 0)
                    {
                        var result = db.Influencer.Where(x => ids.Contains(x.Id))
                            .Select(x => new InFluencerFilter { Id = x.Id, Name = x.Name, City = x.City, Country = x.Country }).ToList();

                        foreach (var c in result)
                        {
                            var url = this._options.Value.GoogleUrl + c + this._options.Value.AndKey + this._options.Value.Key;
                            using (System.Net.Http.HttpClient client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(url);
                                client.DefaultRequestHeaders.Accept.Clear();
                                client.DefaultRequestHeaders.Accept
                                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                                await using Stream stream = await client.GetStreamAsync(url);
                                var maps = await System.Text.Json.JsonSerializer.DeserializeAsync<GeoLocation.MapData>(stream);
                                if (maps != null)
                                {
                                    var entity = new AppApi.Enities.CountryMapData()
                                    {

                                        InfluencerId = c.Id,
                                        PlaceId = maps.Result.PlaceId,
                                        BoundsNELat = maps.Result.Geometry.Bounds.Northeast.Lat,
                                        BoundsNELong = maps.Result.Geometry.Bounds.Northeast.Long,
                                        BoundsSWLat = maps.Result.Geometry.Bounds.Southwest.Lat,
                                        BoundSWLong = maps.Result.Geometry.Bounds.Southwest.Long,
                                        ViewPortNELat = maps.Result.Geometry.ViewPort.NorthEast.Lat,
                                        ViewPortNELong = maps.Result.Geometry.ViewPort.NorthEast.Long,
                                        ViewPortSWLat = maps.Result.Geometry.ViewPort.Southwest.Lat,
                                        ViewPortSWLong = maps.Result.Geometry.ViewPort.Southwest.Long,
                                        LocationLat = maps.Result.Geometry.Locations.lat,
                                        LocationLong = maps.Result.Geometry.Locations.Long
                                    };
                                    maplist.Add(entity);
                                }

                            }


                        }
                        await db.Country.AddRangeAsync(maplist);


                        var t = await db.SaveChangesAsync();
                        _logger.LogInformation("data saved" + " " + t);

                    }
                    else
                    {
                        var result = db.Influencer
                                                .Select(x => new InFluencerFilter { Id = x.Id, Name = x.Name, Country = x.Country }).ToList();

                        foreach (var c in result)
                        {
                            var url = this._options.Value.GoogleUrl + c + this._options.Value.AndKey + this._options.Value.Key;
                            using (System.Net.Http.HttpClient client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(url);
                                client.DefaultRequestHeaders.Accept.Clear();
                                client.DefaultRequestHeaders.Accept
                                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                                

                                await using Stream stream = await client.GetStreamAsync(url);
                                var maps = await System.Text.Json.JsonSerializer.DeserializeAsync<ChannelModels.MapData>(stream);
                                if (maps != null)
                                {
                                    var entity = new AppApi.Enities.CountryMapData()
                                    {

                                        InfluencerId = c.Id,
                                        PlaceId = maps.Result[0].PlaceId,
                                        BoundsNELat = maps.Result[0].Geometry.Bounds.Northeast.Lat,
                                        BoundsNELong = maps.Result[0].Geometry.Bounds.Northeast.Long,
                                        BoundsSWLat = maps.Result[0].Geometry.Bounds.Southwest.Lat,
                                        BoundSWLong = maps.Result[0].Geometry.Bounds.Southwest.Long,
                                        ViewPortNELat = maps.Result[0].Geometry.ViewPort.NorthEast.Lat,
                                        ViewPortNELong = maps.Result[0].Geometry.ViewPort.NorthEast.Long,
                                        ViewPortSWLat = maps.Result[0].Geometry.ViewPort.Southwest.Lat,
                                        ViewPortSWLong = maps.Result[0].Geometry.ViewPort.Southwest.Long,
                                        LocationLat = maps.Result[0].Geometry.Locations.lat,
                                        LocationLong = maps.Result[0].Geometry.Locations.Long
                                    };
                                    maplist.Add(entity);
                                }
                            }
                        }
                        await db.Country.AddRangeAsync(maplist);


                        var t = await db.SaveChangesAsync();
                        _logger.LogInformation("data saved" + " " + t);




                    }
                }
            }
        }           
      
    }
}