using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Notify
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        /// <summary>
        /// 1-Tao moi
        /// 2-Sua
        /// 3-Xoa
        /// 4-Duyet
        /// 5-Tu choi Duyet
        /// </summary>
        public int? ActionType { get; set; }
        /// <summary>
        /// 1-De tai
        /// 2-De cuong
        /// 3-Ke hoach tien san xuat
        /// 4-Duyet  ket thuc san xuat tien ky
        /// 5-Ke hoach hau ky
        /// 6-Duyet ket thuc san xuat hau ky
        /// 7-Duyet phim
        /// </summary>
        public int? ObjectType { get; set; }
        public int? ObjectId { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        /// <summary>
        /// 0-new
        /// 1- Da xem
        /// 2-Da xu ly
        /// </summary>
        public int? Status { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? User { get; set; }
    }
}
