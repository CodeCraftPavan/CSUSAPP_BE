// <copyright file="JwtMiddleware.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CSUSAPP.Common.Helpers
{
    /// <summary>
    /// Middleware for handling JWT authentication in ASP.NET Core applications.
    /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtMiddleware"/> class.
        /// </summary>
        /// <param name="next">next.</param>
        /// <param name="appSettings">appSettings.</param>
        /// <param name="config">config.</param>

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IConfiguration config)
        {
            _next = next;
            _configuration = config;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Invokes the middleware to process the HTTP request and attach user information to the context if a valid JWT token is present.
        /// </summary>
        /// <param name="context">context.</param>
        /// <returns>Nothing returns.</returns>
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                AttachUserToContext(context, token);
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                Console.WriteLine("jwtToken is " + jwtToken);

                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                var userRole = jwtToken.Claims.First(x => x.Type == "role").Value;
                var method = jwtToken.Claims.First(x => x.Type == "method").Value;

                Console.WriteLine("Adding user data to context");
                context.Items["userId"] = Guid.Parse(userId);
                context.Items["userRole"] = userRole;
                context.Items["method"] = method;
            }
            catch
            {
            }
        }
    }
}