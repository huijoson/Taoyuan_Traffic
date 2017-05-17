using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Taoyuan_Traffic.ViewModels.Alert.PublicSub;

namespace Taoyuan_Traffic.ViewModels.Alert
{
    public class AlertDeserialize
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime updated { get; set; }
        public Author author { get; set; }
        public Link link { get; set; }
        public Summary summary { get; set; }
        public Category category { get; set; }
    }
}