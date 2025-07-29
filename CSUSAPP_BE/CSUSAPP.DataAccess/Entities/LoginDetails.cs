// <copyright file="LoginDetails.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSUSAPP.DataAccess.Entities
{
    /// <summary>
    /// Represents the login details of a user in the application.
    /// </summary>
    [Table("session_info")]
    public class LoginDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier for the login details.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the external login identifier associated with the user.
        /// </summary>
        public Guid ExtLogInId { get; set; }

        /// <summary>
        /// Gets or sets the external login identifier associated with the user.
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the session token for the user.
        /// </summary>
        public string? SessionToken { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user logged in.
        /// </summary>
        public DateTime? LoggedInAt { get; set; }

        /// <summary>
        /// Gets or sets the Status of a user.
        /// </summary>
        public LoginStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the status of a user's login session.
    /// </summary>
    public enum LoginStatus
    {
        Pending,
        Completed,
    }
}