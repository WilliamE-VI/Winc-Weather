using System.Web.Http;
using Winc_Weather_API.DAL;
using RestSharp;
using System.Collections.Generic;

namespace Winc_Weather_API.Controllers
{
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        public const string APPID = "4ce152a3a00e4a17bf10c3e0233689be";

        [HttpGet]
        [Route("GetWeather")]
        public object GetWeather(int locationId)
        {
            var location = LocationAccess.GetLocationById(locationId);

            var client = new RestClient("http://api.openweathermap.org/data/2.5/");
            var request = new RestRequest("forecast?zip=" + location.Zipcode + ",us&appid=" + APPID);

            var stuff = client.Execute(request);
            return stuff;
        }

        [HttpGet]
        [Route("GetByZip")]
        public Location GetByZip(string zip)
        {
            return LocationAccess.GetLocationByZip(zip);
        }

        [HttpGet]
        [Route("GetByName")]
        public List<Location> GetByName(string name)
        {
            return LocationAccess.GetLocationsByName(name);
        }

        [HttpPost]
        [Route("Create")]
        public void Create(Location location)
        {
            LocationAccess.AddLocation(location);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public void DeleteById(int locationId)
        {
            LocationAccess.DeleteLocation(locationId);
        }
    }
}