// <copyright file="AuthorizeAttribute.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.Common.Helpers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Represents an authorization attribute that checks user roles.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private string role;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeAttribute"/> class with a specified role.
        /// </summary>
        /// <param name="role">role.</param>
        public AuthorizeAttribute(string role = "guest")
        {
            this.role = role;
        }

        /// <summary>
        /// Executes the authorization logic for the current request.
        /// </summary>
        /// <param name="context">context.</param>
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
