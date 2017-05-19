using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.RealTime
{

    public class RealTimeInfoDeserialize
    {
        public string region { get; set; }
        public string srcdetail { get; set; }
        public string areaNm { get; set; }
        public string UID { get; set; }
        public string direction { get; set; }
        public string y1 { get; set; }
        public string happentime { get; set; }
        public string roadtype { get; set; }
        public string road { get; set; }
        public string modDttm { get; set; }
        public string comment { get; set; }
        public string happendate { get; set; }
        public string x1 { get; set; }
    }
}
