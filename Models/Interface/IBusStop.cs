using System;
using System.Collections.Generic;
using Taoyuan_Traffic.ViewModels;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface IBusStop : IDisposable
    {
        DataClassesDataContext Entity { get; }
        List<ViewModels.BusStopCustom> GetBusStop(IEnumerable<BusStopDeserialize> busStopSource);
    }
}
