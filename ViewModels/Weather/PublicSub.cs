using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Weather
{
    public class PublicSub
    {
    }

    public class Weatherelement
    {
        public string elementName { get; set; }
        public Time[] time { get; set; }
        public string elementMeasure { get; set; }
    }

    public class Time
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string elementValue { get; set; }
        public Parameter[] parameter { get; set; }
        public string dataTime { get; set; }
    }

    public class Parameter
    {
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
    }
}