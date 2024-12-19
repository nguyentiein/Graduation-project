using FPM.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public sealed class UriService : IUriService
    {
        #region Properties
        private readonly string _baseUri;
        #endregion

        #region Constructor
        public UriService(string baseUri)
        {
            this._baseUri = baseUri;
        }

        
        #endregion

        #region Method
        public Uri GetRouteUri(string route) => new Uri(string.Concat(_baseUri, route));
        public string GetBaseUri() => _baseUri;
        #endregion
    }
}
