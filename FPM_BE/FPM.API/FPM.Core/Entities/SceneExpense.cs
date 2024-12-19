using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Core.Entities
{
    public class SceneExpense
    {
        public int Id { get; set; }
        public int? SceneId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? ExpenseTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Reason { get; set; }
        public string? Note { get; set; }
        public SceneExpenseTypeEnum Type { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Commoncategory? ExpenseType { get; set; }
        public virtual Scene? Scene { get; set; }
    }
}
