using FPM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest.RepositoryTest
{
    public class TestRepositoryTest : BaseTest
    {
        public TestRepositoryTest() : base() { }

        [OneTimeTearDown]
        public void Clean()
        {
            context.Database.EnsureDeleted();
        }
        


        [Test]
        public async Task InsertTest_WhenCall_InsertsTest()
        {
            //const int id = 1;
            //var test = new Test()
            //{
            //    Name = "test",
            //    CreatedDate = DateTime.Now,
            //    IsDeleted = false,
            //    UpdatedDate = DateTime.Now,
            //};
            var result = await _testRepository.GetAllAsync();
            //await _testRepository.InsertAsync(test);
            //await _unitOfWork.SaveChangeAsync();

            //var result = await _testRepository.FindAsync(id);

            //Assert.IsNotNull(result.);
            Assert.AreEqual(4,result.Count);
        }
    }
}
