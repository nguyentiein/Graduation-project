using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Config
    {
        public int Id { get; set; }
        public int? TokenExpire { get; set; }
        public int? PageSize { get; set; }
        public string? LogDir { get; set; }
        public long? MaxFileSize { get; set; }
        public string? AllowFileType { get; set; }
        public bool IsDelete { get; set; }
    }
}
