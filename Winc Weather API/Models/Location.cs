using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winc_Weather_API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}