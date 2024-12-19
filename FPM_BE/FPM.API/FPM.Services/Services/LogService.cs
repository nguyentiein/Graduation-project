using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.DTOs.Log.Request;
using FPM.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class LogService : ILogService
    {
        public RequestResponseLogModel LogModel { get; private set; }
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LogService(ILogRepository logRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            LogModel = new RequestResponseLogModel();
            _logRepository = logRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        /// <summary>
        /// chuc nang: luu log vao db
        /// </summary>
        /// <returns></returns>
        public async Task Logging()
        {
            await _logRepository.InsertAsync(_mapper.Map<Log>(LogModel));
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
