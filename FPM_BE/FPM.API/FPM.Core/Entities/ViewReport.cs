using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Core.Entities
{
    public class ViewReport
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("CreateBy")]
        public int? CreateBy { get; set; }
        [JsonPropertyName("Director")]
        public string? Director { get; set; }
        [JsonPropertyName("FromDate")]
        public DateTime? FromDate { get; set; }
        [JsonPropertyName("ToDate")]
        public DateTime? ToDate { get; set; }
        [JsonPropertyName("EstimateFee")]
        public decimal? EstimateFee {  get; set; }
        [JsonPropertyName("FactFee")]
        public decimal? FactFee { get; set; }

    }
}
