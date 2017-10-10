using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winc_Weather_API.DAL
{
    public static class LocationRepo
    {
        public static Location GetLocationByZip(string zip)
        {
            using (var db = new WincWeatherEntities())
            {
                var locations = from location in db.Locations
                                where location.Zipcode == zip
                                select location;
                return locations.FirstOrDefault();
            }
        }

        public static List<Location> GetLocationsByName(string name)
        {
            using (var db = new WincWeatherEntities())
            {
                var locations = from location in db.Locations
                                where location.Name == name
                                select location;
                return locations.ToList();
            }
        }

        public static Location GetLocationById(int locationId)
        {
            using (var db = new WincWeatherEntities())
            {
                var locations = from location in db.Locations
                                where location.Id == locationId
                                select location;
                return locations.FirstOrDefault();
            }
        }

        public static void AddLocation(Location newLocation)
        {
            using (var db = new WincWeatherEntities())
            {
                db.Locations.Add(newLocation);
                db.SaveChanges();
            }
        }

        public static void DeleteLocation(int id)
        {
            using (var db = new WincWeatherEntities())
            {
                var removedLocation = GetLocationById(id);
                if (removedLocation != null)
                { 
                    db.Locations.Attach(removedLocation);
                    db.Locations.Remove(removedLocation);
                    db.SaveChanges();
                }
            }
        }
    }
}