using FPM.Resourses.DTOs.Log.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface ILogService
    {
        RequestResponseLogModel LogModel { get; }

        /// <summary>
        /// Chức năng: lưu log vào DB và File
        /// </summary>
        /// <returns></returns>
        Task Logging();
    }
}
