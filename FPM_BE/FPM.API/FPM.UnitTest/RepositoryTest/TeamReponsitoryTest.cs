using FPM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest.RepositoryTest
{
    public class TeamReponsitoryTest : BaseTest
    {
        public TeamReponsitoryTest() : base() { }

        [OneTimeTearDown]
        public void Clean()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task InsertTeam_WhenCalled_InsertsTeam()
        {
            // Arrange
            var testTeam = new Team()
            {
                Name = "Sample Team",
                Description = "This is a sample team description.",
                LeaderId = 101
            };

            // Act
            await _teamRepository.InsertAsync(testTeam);
            await _unitOfWork.SaveChangeAsync();

            // Assert
            var teams = context.Teams.ToList();
            Assert.AreEqual(1, teams.Count);

        }

        [Test]
        public async Task UpdateTeam_WhenCalled_UpdatesTeam()
        {
            // Arrange
            var testTeam = new Team()
            {
                Name = "Sample Team",
                Description = "This is a sample team description.",
                LeaderId = 101
            };

            await _teamRepository.InsertAsync(testTeam);
            await _unitOfWork.SaveChangeAsync();

            // Act
            testTeam.Name = "Updated Team";
            testTeam.Description = "Updated Description";
            testTeam.LeaderId = 2;
            _teamRepository.Update(testTeam);
            await _unitOfWork.SaveChangeAsync();

            // Assert
            var updatedTeam = context.Teams.FirstOrDefault(t => t.Id == testTeam.Id);
            Assert.IsNotNull(updatedTeam);
            Assert.AreEqual("Updated Team", updatedTeam.Name);
            Assert.AreEqual("Updated Description", updatedTeam.Description);
            Assert.AreEqual(2, updatedTeam.LeaderId);

        }


        [Test]
        public async Task GetTeamById_WhenCalled_ReturnsTeam()
        {

            var testTeam = new Team()
            {
                Name = "Sample Team",
                Description = "This is a sample team description.",
                LeaderId = 101
            };

            await _teamRepository.InsertAsync(testTeam);
            await _unitOfWork.SaveChangeAsync();

            // Act
            var result = await _teamRepository.FindAsync(testTeam.Id);

            // Assert
            Assert.IsTrue(result.HasData);
            Assert.AreEqual("Sample Team", result.Data.Name);
        }


        [Test]
        public async Task DeleteTeam_WhenCalled_DeletesTeam()
        {
            // Arrange
            var testTeam = new Team()
            {
                Name = "Sample Team",
                Description = "This is a sample team description.",
                LeaderId = 101
            };

            await _teamRepository.InsertAsync(testTeam);
            await _unitOfWork.SaveChangeAsync();

            // Act
            _teamRepository.DeleteById(testTeam.Id);
            await _unitOfWork.SaveChangeAsync();

            // Assert
            var teams = context.Teams.ToList();
            Assert.AreEqual(0, teams.Count);

        }
    }
}