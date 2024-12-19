using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionPlaning.Reponse
{
    public class PreproductionReportResponse
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("ScriptFee")]
        public decimal? ScriptFee { get; set; }
        [JsonPropertyName("HumanResourseFee")]
        public decimal? HumanResourseFee { get; set; }
        [JsonPropertyName("CameraFee")]
        public decimal? CameraFee { get; set; }
        [JsonPropertyName("EditFee")]
        public decimal? EditFee { get; set; }
        [JsonPropertyName("OtherFee")]
        public decimal? OtherFee { get; set; }
        [JsonPropertyName("Budget")]
        public decimal? Budget {  get; set; }
        

    }
}
