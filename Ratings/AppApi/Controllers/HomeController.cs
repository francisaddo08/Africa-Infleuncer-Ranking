using AppApi.Data;
using AppApi.Enities;
using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;
        public HomeController(DataContext context) { _context = context; }
        // GET: api/<HomeController>
        [HttpGet]
        public  IEnumerable<InfluencerViewModel> Get()
        {

            List<InfluencerViewModel> list = new List<InfluencerViewModel>();
            //List<ChannelViewModel>? channelList = null;
            //GeoLocationViewModel? geoLocationViewModel = null;
            //var r = this._context.influencers.Include(s => s.Channels).ToList();
            //var result = this._context.influencerNames.Include(d =>d.InfluencerDetail)
            //    .ThenInclude(s => s.Channels)
            //    .OrderByDescending(s => s.InfluencerDetail.TotalFollowers).ToList();
            //foreach (var item in result)
            //{
            //    if (item.InfluencerDetail != null)
            //    {
            //        channelList = new List<ChannelViewModel>();
            //        foreach (var socialItem in item.InfluencerDetail.Channels)
            //        {
            //            socialList.Add(new SocialViewModel { Name = socialItem.Name, Url = socialItem.Url });
            //        }
            //    }
            //    if (item.GeoLocation != null)
            //    {
            //        geoLocationViewModel = new GeoLocationViewModel
            //        {
            //            Country = item.GeoLocation.Country,
            //            CountryCode = item.GeoLocation.CountryCode,
            //            Region = item.GeoLocation.Region,
            //            State = item.GeoLocation.State,
            //            PostCode = item.GeoLocation.PostCode,
            //            City = item.GeoLocation.City,
            //        };
            //    }
            //    list.Add(new InfluencerViewModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        TotalFollowers = item.TotalFollowers,
            //        Description1 = item.Description1,
            //        Description2 = item.Description2,
            //        Description3 = item.Description3,
            //        ImgUrl = item.ImgUrl,
            //        Social = socialList,
            //        GeoLocation = geoLocationViewModel


            //    });

            //}
            return list;
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
