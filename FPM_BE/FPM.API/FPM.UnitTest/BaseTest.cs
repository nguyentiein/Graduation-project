using AutoMapper;
using FPM.Core.Database;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Services.IServices;
using FPM.Services.Mapping;
using FPM.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.UnitTest
{
    public class BaseTest
    {
        #region Property

        //repository
        protected ITestRepository _testRepository;
        protected ITeamRespository _teamRepository;
        protected ITopicRepository _topicRepository;
        protected IUserRepository _userRepository;
        protected IApporvedReponsitory _apporvedReponsitory;
        protected ISceneRepository _sceneRepository;
        protected ISceneExpenseRepository _sceneExpenseRepository;
        protected IUnitOfWork _unitOfWork;

        //Service
        protected IMapper Mapper;
        protected ResponseMessage responseMessage;

        protected ISceneService _sceneService;



        


        
        protected FPMContext context;

        #endregion


        #region Contructor
        public BaseTest()
        {

            context = Configuration.DbFactory();
            context.Seed();


            //repository
            _testRepository = new TestRepository(context);
            _teamRepository = new TeamRepository(context);
            _topicRepository = new TopicReponsitory(context);
            _userRepository = new UserRepository(context);
            _apporvedReponsitory = new ApporvedReponsitory(context);
            _sceneRepository = new SceneRepository(context);
            _sceneExpenseRepository = new SceneExpenseRepository(context);
            _unitOfWork = new UnitOfWork(context);

            //service
            

            //_sceneService = new SceneService(_sceneRepository, _sceneExpenseRepository);

        }

        #endregion
    }


}
