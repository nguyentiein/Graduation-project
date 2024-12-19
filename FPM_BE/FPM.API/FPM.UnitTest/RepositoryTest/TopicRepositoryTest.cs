using FPM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest.RepositoryTest
{
    public class TopicRepositoryTest:BaseTest
    {
        public TopicRepositoryTest() : base() { }

        [OneTimeTearDown]
        public void Clean()
        {
            context.Database.EnsureDeleted();
        }



        [Test]
        public async Task InsertTopic_WhenCall_InsertsTopic()
        {
            const int id = 1;
            var test = new Topic()
            {

                Type = (Resourses.Enums.CommonTypeTopicEnum?)1,
                Name = "Sample Topic",
                Description = "This is a sample topic description.",
                Scenario = "Sample scenario",
                EstimatedBegin = DateTime.Now,
                EstimatedEnd = DateTime.Now.AddDays(7),
                Status = 0,
                CreatedAt = DateTime.Now,
                CreatedBy = 101,
                CategoryId = 5,
                EstimatedBroadcasting = DateTime.Now.AddMonths(1),
                EstimatedBudget = 10000.50M,
                ParentId = 1

            };
           // var result = await _testRepository.GetAllAsync();
            await _topicRepository.InsertAsync(test);
            await _unitOfWork.SaveChangeAsync();

            var topics = context.Topics.ToList();
            Assert.AreEqual(1, topics.Count);
        }

        [Test]
        public async Task DeleteTopic_WhenCalled_DeletesTopic()
        {
            // Arrange
            var testTopic = new Topic()
            {
                Type = (Resourses.Enums.CommonTypeTopicEnum?)1,
                Name = "Sample Topic",
                Description = "This is a sample topic description.",
                Scenario = "Sample scenario",
                EstimatedBegin = DateTime.Now,
                EstimatedEnd = DateTime.Now.AddDays(7),
                Status = 0,
                CreatedAt = DateTime.Now,
                CreatedBy = 101,
                CategoryId = 5,
                EstimatedBroadcasting = DateTime.Now.AddMonths(1),
                EstimatedBudget = 10000.50M,
                ParentId = 1
            };

          
            await _topicRepository.InsertAsync(testTopic);
            await _unitOfWork.SaveChangeAsync();

            
             _topicRepository.DeleteById(testTopic.Id); 
            await _unitOfWork.SaveChangeAsync();

            
            var topics = context.Topics.ToList();
            Assert.AreEqual(0, topics.Count); 
        }

        [Test]
        public async Task UpdateTopic_WhenCalled_UpdatesTopic()
        {
            
            var testTopic = new Topic()
            {
                Type = (Resourses.Enums.CommonTypeTopicEnum?)1,
                Name = "Original Topic",
                Description = "Original Description",
                Scenario = "Original Scenario",
                EstimatedBegin = DateTime.Now,
                EstimatedEnd = DateTime.Now.AddDays(7),
                Status = 0,
                CreatedAt = DateTime.Now,
                CreatedBy = 101,
                CategoryId = 5,
                EstimatedBroadcasting = DateTime.Now.AddMonths(1),
                EstimatedBudget = 10000.50M,
                ParentId = 1
            };

           
            await _topicRepository.InsertAsync(testTopic);
            await _unitOfWork.SaveChangeAsync();

            
            testTopic.Name = "Updated Topic";
            testTopic.Description = "Updated Description";
            testTopic.Status = 1;
            _topicRepository.Update(testTopic);
            await _unitOfWork.SaveChangeAsync();

           
            var updatedTopic = context.Topics.FirstOrDefault(t => t.Id == testTopic.Id);
            Assert.IsNotNull(updatedTopic);
            Assert.AreEqual("Updated Topic", updatedTopic.Name);
            Assert.AreEqual("Updated Description", updatedTopic.Description);
            Assert.AreEqual(1, updatedTopic.Status);
        }


        [Test]
        public async Task GetTopicById_WhenCalled_ReturnsTopic()
        {
            // Arrange
            var testTopic = new Topic()
            {
                Type = (Resourses.Enums.CommonTypeTopicEnum?)1,
                Name = "Sample Topic",
                Description = "This is a sample topic description.",
                Scenario = "Sample scenario",
                EstimatedBegin = DateTime.Now,
                EstimatedEnd = DateTime.Now.AddDays(7),
                Status = 0,
                CreatedAt = DateTime.Now,
                CreatedBy = 101,
                CategoryId = 5,
                EstimatedBroadcasting = DateTime.Now.AddMonths(1),
                EstimatedBudget = 10000.50M,
                ParentId = 1
            };

        
            await _topicRepository.InsertAsync(testTopic);
            await _unitOfWork.SaveChangeAsync();

            var result = await _topicRepository.GetTopicByIdAsync(testTopic.Id);

            Assert.IsTrue(result.HasData);
        }

    }


    
}
