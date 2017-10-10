using System;
using System.Data.Entity;
using System.Linq;

namespace Winc_Weather_API.DAL
{
    public static class CacheRepo
    {
        public static void SaveResponse(string response, int locationId)
        {
            using (var db = new WincWeatherEntities())
            {
                db.WeatherCaches.Add(
                    new WeatherCache {
                        Response = response,
                        LocationId = locationId,
                        TimeReceived = DateTime.Now
                    });
                db.SaveChanges();
            }
        }

        public static string GetResponseFromLastFiveMinutesByLocationId(int locationId)
        {
            using (var db = new WincWeatherEntities())
            {
                return db.WeatherCaches.FirstOrDefault(n => 
                    n.LocationId == locationId &&
                    n.TimeReceived > DbFunctions.AddMinutes(DateTime.Now, -5)
                    )?.Response;
            }
        }
    }
}