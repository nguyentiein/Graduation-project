using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Test.Request
{
    public class CreateTestRequest
    {
        [Required]
        public string Name { get; set; }

    }
}
