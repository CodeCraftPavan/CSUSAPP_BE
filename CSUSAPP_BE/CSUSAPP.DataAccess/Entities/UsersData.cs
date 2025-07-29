// <copyright file="UsersData.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents the user details in the application.
    /// </summary>
    [Table("user_details")]
    public class UsersData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        public Roles Roles { get; set; }

        /// <summary>
        /// Gets or sets the first name and last name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? UserEmailId { get; set; }

        /// <summary>
        /// Gets or sets the contact number of the user.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the salt used for password hashing.
        /// </summary>
        public string? Salt { get; set; }
    }
}
