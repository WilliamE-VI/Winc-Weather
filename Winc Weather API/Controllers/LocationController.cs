using System.Web.Http;
using Winc_Weather_API.Models;

namespace Winc_Weather_API.Controllers
{
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public void Create(Location location)
        {

        }
    }
}