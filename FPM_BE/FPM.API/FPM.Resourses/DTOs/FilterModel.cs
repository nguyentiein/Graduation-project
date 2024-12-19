using FPM.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs
{
    public class FilterModelRequest<T> : QueryResource
    {
        public T? FilterModel { get; set; }
    }
}
