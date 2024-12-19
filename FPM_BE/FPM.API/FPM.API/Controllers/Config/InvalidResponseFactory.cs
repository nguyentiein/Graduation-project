using FPM.Resourses;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using FPM.Extensions;
using FPM.Resourses.Results;

namespace FPM.API.Controllers.Config
{
    public static class InvalidResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var error = context.ModelState.GetErrorMessages();
            var response = new BaseResult<object>()
            {
                Message = Global.IsDebug ? error : "Dữ liệu không hợp lệ",
                Status = Resourses.Enums.StatusEnum.Failed,
                StatusCode = EnumExtensions.GetElementNameCodeMessage(CodeMessage._98)
            };

            return new BadRequestObjectResult(response);
        }

        public static string GetErrorMessages(this ModelStateDictionary dictionary)
            => dictionary.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage).FirstOrDefault();
    }
}
