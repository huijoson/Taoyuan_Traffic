using System;
using System.Collections.Generic;
using Taoyuan_Traffic.ViewModels.TRA;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface ITraLine : IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        void AddTraLine(IEnumerable<TraLineDeserialize> traLineResource);

        void AddStation(IEnumerable<TraStationDeserialize> traStationResource);

        void AddTraClass(IEnumerable<TraClassDeserialize> traClassResource);

        List<TraDailyTimeTableDeserialize> GetTraDailyTimetable(IEnumerable<TraDailyTimeTableDeserialize> traDailyTimetableReaource, string hhmm);

        List<TraLineDeserialize> GetTraLine();

        string GetStationID(string StationName);

    }
}
