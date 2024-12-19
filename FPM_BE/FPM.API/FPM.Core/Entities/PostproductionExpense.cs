using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Core.Entities
{
    public class PostproductionExpense
    {
        public int Id { get; set; } //
        public int? PostProductPlaningId { get; set; }
        public string? TaskName { get; set; } //
        public string? Description { get; set; } //
        public decimal? TimeEstimate { get; set; } //
        public decimal? HumanResourceEstimate { get; set; } //
        public decimal? OtherResourceEstimate { get; set; } //
        public int? Phase { get; set; } //
        public string? TypeFilm { get; set; } //


        // Thời lượng
        public TimeSpan Duration { get; set; } //

        // Phí kịch bản
        public decimal ScriptFee { get; set; } //

        // Phí cameraman
        public decimal CameramanFee { get; set; } //chi phí cảnh quay

        // Phí editor
        public decimal EditorFee { get; set; } //chi phí chỉnh sửa


        //thoi luong
        //phi kich ban
        //phi nha san xuat
        //phi dao dien
        //phi camerama
        //phi edittor
        //phi nhan luc khac

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public int? CreatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual PostproductionPlaning? PostProductPlaning { get; set; }
        public bool IsDeleted { get; set; }
    }
}
