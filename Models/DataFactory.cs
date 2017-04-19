using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.Models.Repository;

namespace Taoyuan_Traffic.Models
{
    public class DataFactory
    {
        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IBusDynamic BusDynamicRepository(DataClassesDataContext dataContext = null)
        {
            return new BusDynamicRepository(dataContext);
        }
    }
}