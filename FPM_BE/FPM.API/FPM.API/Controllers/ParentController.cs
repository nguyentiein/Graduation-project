using FPM.Extensions;
using FPM.Resourses;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    public abstract class ParentController : ControllerBase
    {
        #region Property
        protected readonly ResponseMessage ResponseMessage;
        protected readonly IMapper Mapper;
        #endregion

        #region Constructor
        protected ParentController(IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper)
        {
            ResponseMessage = responseMessage.CurrentValue;
            Mapper = mapper;
        }
        #endregion

        #region Method
        protected virtual BaseResult<Inner> GetBaseResult<Inner>(CodeMessage statusCode, Inner data = default, StatusEnum status = StatusEnum.Success, string message = "")
        {
            string nameStatusCode = statusCode.GetElementNameCodeMessage();

            string tempCode = string.IsNullOrEmpty(nameStatusCode) ? "217" : nameStatusCode.RemoveSpaceCharacter();
            string tempMessage = string.IsNullOrEmpty(message) ? ResponseMessage.Values[tempCode].RemoveSpaceCharacter() : message.RemoveSpaceCharacter();

            return new BaseResult<Inner>()
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
