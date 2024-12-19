using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses
{
    public class QueryResource
    {
        #region Property
        [Range(1, int.MaxValue)]
        public int Page { get; set; }

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
        #endregion
    }
}
