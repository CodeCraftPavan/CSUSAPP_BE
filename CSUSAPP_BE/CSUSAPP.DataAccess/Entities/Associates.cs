// <copyright file="Associates.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSUSAPP.DataAccess.Entities
{
    /// <summary>
    /// Represents an associate entity in the application.
    /// </summary>
    [Table("associates")]
    public class Associates
    {
        /// <summary>
        /// Gets or sets the unique identifier for the associate.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the AssociateName for the associate.
        /// </summary>
        public string AssociateName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associate.
        /// </summary>
        public Roles Role { get; set; }

        /// <summary>
        /// Gets or sets the ContactInformation for the associate.
        /// </summary>
        public string ContactInformation { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBy for the associate.
        /// </summary>
        public Guid UpdatedBy { get; set; }

        // Foreign Key

        /// <summary>
        /// Gets or sets the CustomerDetailsId for the associate.
        /// </summary>
        public long CustomerDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the CustomerDetails for the associate.
        /// </summary>
        public CustomerDetails CustomerDetails { get; set; }
    }

    /// <summary>
    /// Represents the roles available for associates in the application.
    /// </summary>
    public enum Roles
    {
        Admin,
        Users,
    }
}
