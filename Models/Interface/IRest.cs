﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taoyuan_Traffic.ViewModels.Rest;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface IRest : IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        void AddRestInfo(IEnumerable<RestDeserialize> addUBikeResource);
        List<RestDeserialize> GetRestInfo();
    }
}
