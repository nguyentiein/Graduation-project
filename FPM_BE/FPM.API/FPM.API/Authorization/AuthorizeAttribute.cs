using FPM.Core.Entities;
using FPM.Resourses.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using System.Linq;

namespace FPM.API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<RoleEnum> _roles;

        public AuthorizeAttribute(params RoleEnum[] roles)
        {
            _roles = roles ?? new RoleEnum[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (User)context.HttpContext.Items["User"];

            if(user == null) context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            if (user != null)
            {
                var userRoles = user.Roles.Select(x => x.Type).ToList();

                bool flag = false;
                


                foreach(var role in userRoles)
                {
                    if(_roles.Any() && _roles.Contains(role))
                    {
                        flag =true;
                    }
                }
                if(!_roles.Any()) flag = true;



                if (!flag) context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            } 
        }
    }
}
