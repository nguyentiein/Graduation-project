using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Core.Entities
{
    public class Scene
    {
        public Scene()
        {
            SceneExpenses = new HashSet<SceneExpense>();
        }

        public int Id { get; set; }
        public int? PreproductionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? EditBudget {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? PreproductionSegmentId { get; set; }
        public virtual PreproductionSegment? PreproductionSegment { get; set; }
        public virtual ICollection<SceneExpense>? SceneExpenses { get; set; }

    }
}
