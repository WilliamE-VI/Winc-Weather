using System.Web.Http;
using Winc_Weather_API.DAL;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            string responseString = CacheRepo.GetResponseFromLastFiveMinutesByLocationId(locationId);
            if (string.IsNullOrEmpty(responseString))
            {

                var location = LocationRepo.GetLocationById(locationId);

                var client = new RestClient("http://api.openweathermap.org/data/2.5/");
                var request = new RestRequest("forecast?zip=" + location.Zipcode + ",us&appid=" + APPID + "&units=imperial");

                var response = client.Execute(request);
                responseString = response.Content;
                CacheRepo.SaveResponse(responseString, locationId);
            }
            var responseObject = JsonConvert.DeserializeObject<object>(responseString);
            return responseObject;
        }

        [HttpGet]
        [Route("GetByZip")]
        public Location GetByZip(string zip)
        {
            return LocationRepo.GetLocationByZip(zip);
        }

        [HttpGet]
        [Route("GetByName")]
        public List<Location> GetByName(string name)
        {
            return LocationRepo.GetLocationsByName(name);
        }

        [HttpPost]
        [Route("Create")]
        public void Create(Location location)
        {
            LocationRepo.AddLocation(location);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public void DeleteById(int locationId)
        {
            LocationRepo.DeleteLocation(locationId);
        }
    }
}