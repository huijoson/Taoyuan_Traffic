using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.TRA
{
    public class TraDailyTimeTableDeserialize
    {
        public string TrainDate { get; set; }
        public Dailytraininfo DailyTrainInfo { get; set; }
        public Originstoptime OriginStopTime { get; set; }
        public Destinationstoptime DestinationStopTime { get; set; }
        public string UpdateDate { get; set; }
    }
}