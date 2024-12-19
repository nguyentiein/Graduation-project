using FPM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest.RepositoryTest
{
    public class UserRepositoryTest : BaseTest
    {
        public UserRepositoryTest() : base() 
        {
        }

        [OneTimeTearDown]
        public void Clean()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetUserByIdTest_WhenCall_GetUserByIdsTest()
        {
            //set up
            const int id = 1;
            var user = new User()
            {
                Email = "ntung7584@gmail.com",
                FirstName = "abc",
                LastName = "abc",
            };
            await _userRepository.InsertAsync(user);
            await _unitOfWork.SaveChangeAsync();

            //test

            var result = await _userRepository.GetUserById(id);

            Assert.IsTrue(result.HasData);
        }

    }
}
