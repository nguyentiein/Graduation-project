﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Test.Request
{
    public class UpdateTestRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
