// <copyright file="AuthUser.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace CSUSAPP.Common.Auth
{
    /// <summary>
    /// Represents an authenticated user in the application.
    /// </summary>
    public class AuthUser : IAuthUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthUser"/> class.
        /// </summary>
        public AuthUser()
        {
        }

        /// <summary>
        /// Gets the identity of the authenticated user.
        /// </summary>
        public UserIdentity Identity { get; init; }

        /// <summary>
        /// Gets a value indicating whether the user is authenticated.
        /// </summary>
        public bool IsAuthenticated => Identity != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthUser"/> class using the provided HttpContext.
        /// </summary>
        /// <param name="context">context.</param>
        public AuthUser(HttpContext context)
        {
            var authUserId = context.Items["userId"];

            Console.WriteLine("Auth user is being set here: userId is " + authUserId);

            if (authUserId != null)
            {
                this.Identity = new UserIdentity
                {
                    UserId = (Guid)authUserId,
                };
            }

            string authUserRole = (string)context.Items["userRole"];
            string method = (string)context.Items["method"];

            // Log.Information("authUserRole is " + authUserRole);
            if (authUserRole != null)
            {
                var roles = authUserRole.Split(',');

                var userRoles = new List<string>();

                foreach (var r in roles)
                {
                    // var userRole = string.IsNullOrEmpty(r) ? UserRole.guest : ResolveEnumMember.FromString<UserRole>(r);
                    userRoles.Add(r);
                }

                Identity.UserRoles = userRoles;
            }
        }
    }

    /// <summary>
    /// Represents the identity of a user in the application.
    /// </summary>
    public class UserIdentity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the roles associated with the user.
        /// </summary>
        public List<string> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets the session token for the user.
        /// </summary>
        public string SessionToken { get; set; }
    }

    /// <summary>
    /// Represents an interface for authenticated users in the application.
    /// </summary>
    public interface IAuthUser
    {
        /// <summary>
        /// Gets a value indicating whether the user is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Gets the identity of the authenticated user.
        /// </summary>
        UserIdentity Identity { get; init; }
    }
}