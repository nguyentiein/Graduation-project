using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Estimate.Request
{
    public class CreateEstimateRequest
    {

        public int? PreProductPlaningId { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public decimal? TimeEstimate { get; set; }
        public decimal? HumanResourceEstimate { get; set; }
        public decimal? OtherResourceEstimate { get; set; }
        public int? Phase { get; set; }
        public string? TypeFilm { get; set; }


        // Thời lượng
        public TimeSpan Duration { get; set; }

        // Phí kịch bản
        public decimal ScriptFee { get; set; }

        // Phí nhà sản xuất
        public decimal ProducerFee { get; set; }

        // Phí đạo diễn
        public decimal DirectorFee { get; set; }

        // Phí cameraman
        public decimal CameramanFee { get; set; }

        // Phí editor
        public decimal EditorFee { get; set; }


        //thoi luong
        //phi kich ban
        //phi nha san xuat
        //phi dao dien
        //phi camerama
        //phi edittor
        //phi nhan luc khac

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
    }
}
