using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Weather
{
    public class Weather3DayDeserialize
    {
        public string locationName { get; set; }
        public string geocode { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public Weatherelement[] weatherElement { get; set; }
    }
    
}