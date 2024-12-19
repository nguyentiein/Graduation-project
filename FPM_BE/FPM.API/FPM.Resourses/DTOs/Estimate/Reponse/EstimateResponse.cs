using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Estimate.Reponse
{
    public  class EstimateResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("PreProductPlaningId")]
        public int? PreProductPlaningId { get; set; }

        [JsonPropertyName("TaskName")]
        public string? TaskName { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("TimeEstimate")]
        public decimal? TimeEstimate { get; set; }

        [JsonPropertyName("HumanResourceEstimate")]
        public decimal? HumanResourceEstimate { get; set; }

        [JsonPropertyName("OtherResourceEstimate")]
        public decimal? OtherResourceEstimate { get; set; }

        [JsonPropertyName("Phase")]
        public int? Phase { get; set; }

        [JsonPropertyName("TypeFilm")]
        public string? TypeFilm { get; set; }

        [JsonPropertyName("Duration")]
        public TimeSpan Duration { get; set; }

        [JsonPropertyName("ScriptFee")]
        public decimal ScriptFee { get; set; }

        [JsonPropertyName("ProducerFee")]
        public decimal ProducerFee { get; set; }

        [JsonPropertyName("DirectorFee")]
        public decimal DirectorFee { get; set; }

        [JsonPropertyName("CameramanFee")]
        public decimal CameramanFee { get; set; }

        [JsonPropertyName("EditorFee")]
        public decimal EditorFee { get; set; }

        [JsonPropertyName("OtherLaborFee")]
        public decimal OtherLaborFee { get; set; }

        [JsonPropertyName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("CreatedBy")]
        public int? CreatedBy { get; set; }
    }
}
