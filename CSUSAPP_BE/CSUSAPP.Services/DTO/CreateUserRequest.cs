// <copyright file="CreateUserRequest.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.DataAccess.Entities;

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the request to create a new user.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Gets or sets the FirstName for the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName for the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the roles for the user.
        /// </summary>
        public Roles Roles { get; set; }

        /// <summary>
        /// Gets or sets the UserEmailId for the user.
        /// </summary>
        public string UserEmailId { get; set; }

        /// <summary>
        /// Gets or sets the Password for the user.
        /// </summary>
        public string Password { get; set; }
    }
}
