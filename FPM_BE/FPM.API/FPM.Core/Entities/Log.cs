#nullable disable
using FPM.Extensions;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Log
    {
        public string Id { get; set; }
        public string Node { get; set; }
        public string ClientIp { get; set; }
        public string TraceId { get => traceId; set => traceId = value.ReplaceChar(); }
        private string traceId;
        public DateTime RequestDatetimeUtc { get; set; }
        public string RequestPath { get; set; }
        public string RequestQuery { get; set; }
        public string RequestMethod { get; set; }
        public string RequestHost { get; set; }
        public string RequestBody { get; set; }
        public string RequestContentType { get; set; }
        public DateTime ResponseDatetimeUtc { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
        public string ResponseContentType { get; set; }
        public bool HasException { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
    }
}
