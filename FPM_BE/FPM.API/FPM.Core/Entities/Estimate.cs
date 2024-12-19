using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public int? PreProductPlaningId { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public decimal? TimeEstimate { get; set; }
        public decimal? HumanResourceEstimate { get; set; }
        public decimal? OtherResourceEstimate { get; set; }
        public int? Phase { get; set; }
        public string ?TypeFilm { get; set; }


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

        public virtual User? CreatedByNavigation { get; set; }
        public virtual PreproductionPlaning? PreProductPlaning { get; set; }
        public bool IsDeleted { get; set; }
    }
}
