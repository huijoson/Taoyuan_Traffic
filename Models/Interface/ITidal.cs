using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taoyuan_Traffic.ViewModels.Tidal;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface ITidal : IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        /// <summary>
        /// 新增潮汐資訊
        /// </summary>
        int addTidalInfo(IEnumerable<TidalDeserialize> weatherInfoSource, int rowCount, string localname);
        /// <summary>
        /// 清潮汐資料
        /// </summary>
        void clearTidalTable();
        /// <summary>
        /// 取得潮汐資料
        /// </summary>
        /// <param name="keyWord">地區關鍵字</param>
        /// <returns></returns>
        List<TidalCusDeserialize> getTidalInfo(string keyWord);
    }
}
