using FPM.Core.Database;
using FPM.Resourses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest
{
    public static class Configuration
    {
        public static FPMContext DbFactory()
        {
            DbContextOptions<FPMContext> options = new DbContextOptionsBuilder<FPMContext>()
                                                        .UseInMemoryDatabase(databaseName: "FPMTest")
                                                        .Options;
            return new FPMContext(options);
        }

    }
}
