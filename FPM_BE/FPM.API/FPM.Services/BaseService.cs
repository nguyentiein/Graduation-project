using FPM.Resourses.Enums;
using FPM.Resourses;
using FPM.Resourses.Results;
using FPM.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace FPM.Services
{
    public abstract class BaseService
    {
        #region Property
        protected readonly IMapper Mapper;
        protected readonly ResponseMessage ResponseMessage;
        #endregion

        #region Constructor
        public BaseService(IMapper mapper,
            IOptionsMonitor<ResponseMessage> responseMessage)
        {
            Mapper = mapper;
            ResponseMessage = responseMessage.CurrentValue;
        }
        #endregion

        #region Method
        protected virtual BaseResult<Inner> GetBaseResult<Inner>(CodeMessage statusCode, Inner data = default, StatusEnum status = StatusEnum.Success, string message = "")
        {
            string nameStatusCode = statusCode.GetElementNameCodeMessage();

            string tempCode = string.IsNullOrEmpty(nameStatusCode) ? "217" : nameStatusCode.RemoveSpaceCharacter();
            string tempMessage = string.IsNullOrEmpty(message) || message.Length > 500 ? ResponseMessage.Values[tempCode].RemoveSpaceCharacter() : message.RemoveSpaceCharacter();

            return new BaseResult<Inner>()
            {
                StatusCode = tempCode,
                Data = data,
                Status = status,
                Message = tempMessage
            };
        }

        protected virtual PaginationResult<Inner> GetPaginationResult<Inner>(CodeMessage statusCode, Inner data = default, StatusEnum status = StatusEnum.Success, string message = "")
        {
            string nameStatusCode = statusCode.GetElementNameCodeMessage();

            string tempCode = string.IsNullOrEmpty(nameStatusCode) ? "217" : nameStatusCode.RemoveSpaceCharacter();
            string tempMessage = string.IsNullOrEmpty(message) ? ResponseMessage.Values[tempCode].RemoveSpaceCharacter() : message.RemoveSpaceCharacter();

            return new PaginationResult<Inner>()
            {
                StatusCode = tempCode,
                Data = data,
                Status = status,
                Message = tempMessage
            };
        }
        #endregion
    }
}
