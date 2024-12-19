using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.Enums
{
    public enum ApproveObjectTypeEnum
    {
        Topic = 0,
        Outline = 1,
        preproductionPlan = 2
    }

    public enum ApproveResultEnum
    {
        Update = -1,
        Approving = 0,
        Accept = 1,
        Reject = 2
    }
}
