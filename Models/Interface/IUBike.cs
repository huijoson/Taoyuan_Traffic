using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taoyuan_Traffic.ViewModels.Ubike;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface IUBike : IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        void AddUBikeInfo(IEnumerable<UBikeDeserialize> addUBikeResource);
        List<UBikeDeserialize> GetUbikeInfo();
    }
}
