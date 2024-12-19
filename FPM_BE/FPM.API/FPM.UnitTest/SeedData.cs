using FPM.Core.Database;
using FPM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest
{
    public static class SeedData
    {
        public static void Seed(this FPMContext context)
        {
            context.Tests.AddRange(GetTests());

            context.SaveChanges();
        }


        private static ICollection<Test> GetTests()
        {
            return new List<Test>()
            {
                new Test
                {
                    Id = 1,
                    Name = "Test1",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Test
                {
                    Id = 2,
                    Name = "Test2",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Test
                {
                    Id = 3,
                    Name = "Test3",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Test
                {
                    Id = 4,
                    Name = "Test4",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                }
            };
        }
    }
}
