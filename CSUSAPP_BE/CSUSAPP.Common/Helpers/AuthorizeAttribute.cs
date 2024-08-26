using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Common.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute: Attribute, IAuthorizationFilter
    {
        private string role;

        public AuthorizeAttribute(string role = "guest")
        {
            this.role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.Items["userId"];

            if (userId == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized. No user id was found." }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                var userRole = (String)context.HttpContext.Items["userRole"];

                if (role != "guest")
                {
                    if (userRole == null)
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized. No role was found" }) { StatusCode = StatusCodes.Status401Unauthorized };

                    }

                    if (!userRole.Contains(role))
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized. Wrong role was found" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    }
                }
            }
        }
    }
}
