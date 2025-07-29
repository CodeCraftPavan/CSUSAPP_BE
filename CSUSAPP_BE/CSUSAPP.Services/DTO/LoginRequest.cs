// <copyright file="LoginRequest.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the request data for user login.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// Represents the response data for user authentication.
    /// </summary>
    public class AuthUserResponse
    {
        /// <summary>
        /// Gets or sets the first name of the authenticated user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the authenticated user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the token of the authenticated user.
        /// </summary>
        public string Token { get; set; }
    }
}
