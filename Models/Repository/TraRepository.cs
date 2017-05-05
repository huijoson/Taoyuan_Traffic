using System;
using System.Collections.Generic;
using System.Linq;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.ViewModels.TRA;

namespace Taoyuan_Traffic.Models.Repository
{
    public class TraRepository : ITraLine
    {

        /// <summary>
        /// (私有) 資料庫實體資料集合
        /// </summary>
        private DataClassesDataContext _db;

        /// <summary>
        /// 目前時間
        /// </summary>
        private DateTime _now = DateTime.Now;

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        public TraRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public TraRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~TraRepository()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        public DataClassesDataContext Entity
        {
            get
            {
                return _db;
            }
        }

        #region 實作IDisposable

        private bool _disposed = false;

        /// <summary>
        /// 資源釋放
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    if (_db != null) _db.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion 實作IDisposable

        /// <summary>
        /// 新增路線資料至資料庫
        /// </summary>
        /// <param name="traLineResource"></param>
        public void AddTraLine(IEnumerable<TraLineDeserialize> traLineResource)
        {
            var count = 1;
            _db.ExecuteCommand("DELETE FROM TraLine");
            foreach (TraLineDeserialize item in traLineResource)
            {
                var newTraLine = new TraLine
                {
                    LineNo = item.LineNo,
                    LineID = item.LineID,
                    LineNameEn = item.LineNameEn,
                    LineNameZh = item.LineNameZh,
                    LineSectionNameEn = item.LineSectionNameEn,
                    LineSectionNameZh = item.LineSectionNameZh,
                    IsBranch = item.IsBranch
                };
                count++;
                _db.TraLine.InsertOnSubmit(newTraLine);
                _db.SubmitChanges();
            }
        }

        /// <summary>
        /// 新增車站資料至資料庫
        /// </summary>
        /// <param name="traStationResource"></param>
        public void AddStation(IEnumerable<TraStationDeserialize> traStationResource)
        {
            var count = 1;
            _db.ExecuteCommand("DELETE FROM TraStation");
            foreach (TraStationDeserialize item in traStationResource)
            {
                var newTraStation = new TraStation
                {
                    StationID = item.StationID,
                    Zh_tw = item.StationName.Zh_tw,
                    En = item.StationName.En,
                    PositionLat = item.StationPosition.PositionLat,
                    PositionLon = item.StationPosition.PositionLon,
                    StationAddress = item.StationAddress,
                    StationPhone = item.StationPhone,
                    OperatorID = item.OperatorID,
                    StationClass = item.StationClass,
                    ReservationCode = item.ReservationCode

                };
                count++;
                _db.TraStation.InsertOnSubmit(newTraStation);
                _db.SubmitChanges();
            }
        }

        public void AddTraClass(IEnumerable<TraClassDeserialize> traClassResource)
        {
            var count = 1;
            _db.ExecuteCommand("DELETE FROM TraClass");
            foreach (TraClassDeserialize item in traClassResource)
            {
                var newTraClass = new TraClass
                {
                    TrainClassificationID = item.TrainClassificationID,
                    Zh_tw = item.TrainClassificationName.Zh_tw,
                    En = item.TrainClassificationName.Zh_tw
                };
                count++;
                _db.TraClass.InsertOnSubmit(newTraClass);
                _db.SubmitChanges();
            }
        } 
    
        public List<TraLineDeserialize> GetTraLine()
        {
            List<TraLineDeserialize> traLineList = (from o in _db.TraLine
                                                               select new TraLineDeserialize()
                                                               {
                                                                   LineNo = o.LineNo,
                                                                   LineID = o.LineID,
                                                                   LineNameZh = o.LineNameZh,
                                                                   LineNameEn = o.LineNameEn,
                                                                   LineSectionNameZh = o.LineSectionNameZh,
                                                                   LineSectionNameEn = o.LineSectionNameEn,
                                                                   IsBranch = o.IsBranch.HasValue ? o.IsBranch.Value : false
                                                               }).ToList();
            return traLineList;
        }

        public List<TraDailyTimeTableDeserialize> GetTraDailyTimetable(IEnumerable<TraDailyTimeTableDeserialize> traDailyTimetableReaource, string hhmm)
        {
            DateTime dt1 = Convert.ToDateTime(hhmm);
            List<TraDailyTimeTableDeserialize> List = new List<TraDailyTimeTableDeserialize>();
            foreach (TraDailyTimeTableDeserialize item in traDailyTimetableReaource)
            {
                
                if(Convert.ToDateTime(item.OriginStopTime.DepartureTime) > dt1)
                { 
                    TraDailyTimeTableDeserialize DTT = new TraDailyTimeTableDeserialize();
                    //DTT.TrainDate = item.TrainDate;
                    //DTT.DailyTrainInfo.TrainNo = item.DailyTrainInfo.TrainNo;
                    //DTT.DailyTrainInfo.Direction = item.DailyTrainInfo.Direction;
                    //DTT.DailyTrainInfo.StartingStationID = item.DailyTrainInfo.StartingStationID;
                    //DTT.DailyTrainInfo.StartingStationName = item.DailyTrainInfo.StartingStationName;
                    //DTT.DailyTrainInfo.EndingStationID = item.DailyTrainInfo.EndingStationID;
                    //DTT.DailyTrainInfo.EndingStationName = item.DailyTrainInfo.EndingStationName;
                    //DTT.DailyTrainInfo.TrainClassificationID = item.DailyTrainInfo.TrainClassificationID;
                    //DTT.DailyTrainInfo.TripLine = item.DailyTrainInfo.TripLine;
                    //DTT.DailyTrainInfo.WheelchairFlag = item.DailyTrainInfo.WheelchairFlag;
                    //DTT.DailyTrainInfo.PackageServiceFlag = item.DailyTrainInfo.PackageServiceFlag;
                    //DTT.DailyTrainInfo.DiningFlag = item.DailyTrainInfo.DiningFlag;
                    //DTT.DailyTrainInfo.BikeFlag = item.DailyTrainInfo.BikeFlag;
                    //DTT.DailyTrainInfo.BreastFeedingFlag = item.DailyTrainInfo.BreastFeedingFlag;
                    //DTT.DailyTrainInfo.DailyFlag = item.DailyTrainInfo.DailyFlag;
                    //DTT.DailyTrainInfo.ServiceAddedFlag = item.DailyTrainInfo.ServiceAddedFlag;
                    //DTT.DailyTrainInfo.Note.Zh_tw = item.DailyTrainInfo.Note.Zh_tw;
                    //DTT.DailyTrainInfo.Note.En = item.DailyTrainInfo.Note.En;
                    //DTT.UpdateDate = item.UpdateDate;
                    ////起站時間
                    //DTT.OriginStopTime = item.OriginStopTime;
                    ////到站時間
                    //DTT.DestinationStopTime = item.DestinationStopTime;
                    DTT = item;
                    List.Add(DTT);
                }
            }
            return List;
        }

        public string GetStationID(string StationName)
        {
            var stationIDQuery = (from o in _db.TraStation
                            where o.Zh_tw.Equals(StationName)
                            select o.StationID).AsQueryable().ToList();
            string stationID="";

            foreach (string item in stationIDQuery)
            {
                stationID = item;
            }
            return stationID;
        }
    }
}