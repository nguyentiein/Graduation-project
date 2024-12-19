using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IUriService
    {
        /// <summary>
        /// Chức năng: tạo uri với host hiện tại của server
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        Uri GetRouteUri(string route);

        /// <summary>
        /// Chức năng: lấy base uri với host hiện tại
        /// </summary>
        /// <returns></returns>
        string GetBaseUri();

    }
}
