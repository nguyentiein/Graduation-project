using FPM.Resourses;
using FPM.Resourses.Results;
using Microsoft.Extensions.Options;
using FPM.Extensions;
using System.Net;
using System.Resources;
using System.Text.Json;
using FPM.Resourses.CustomException;

namespace FPM.API.Controllers.Middlewares
{
    public sealed class ErrorHandlerMiddleware
    {
        #region Property
        private readonly RequestDelegate _next;
        private readonly ResponseMessage _responseMessage;
        #endregion

        #region Constructor
        public ErrorHandlerMiddleware(RequestDelegate next, IOptionsMonitor<ResponseMessage> responseMessage)
        {
            this._next = next;
            this._responseMessage = responseMessage.CurrentValue;
        }
        #endregion

        #region Method
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string messageError;
                string tempCode;

                // Using switch for custom exception
                switch (error)
                {
                    // Add custom exception code below!
                    case TaskCanceledException ex:
                        tempCode = CodeMessage._245.GetElementNameCodeMessage();
                        messageError = _responseMessage.Values[tempCode];
                        response.StatusCode = (int)HttpStatusCode.BadGateway;
                        break;
                    case MessageResultException ex:
                        tempCode = CodeMessage._99.GetElementNameCodeMessage();
                        messageError = _responseMessage.Values[tempCode];
                        response.StatusCode = (int)HttpStatusCode.BadGateway;
                        break;
                    case UnauthorizedResultException ex:
                        tempCode = CodeMessage._401.GetElementNameCodeMessage();
                        messageError = _responseMessage.Values[tempCode];
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        // unhandled error
                        tempCode = CodeMessage._99.GetElementNameCodeMessage();
                        messageError = _responseMessage.Values[tempCode];
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new BaseResult<object>()
                {
                    Message = messageError,
                    Status = Resourses.Enums.StatusEnum.Failed,
                    StatusCode = tempCode
                });
                await response.WriteAsync(result);

                throw;
            }
        }
        #endregion
    }
}
