// <copyright file="Services.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace CSUSAPP.DataAccess.Entities
{
    /// <summary>
    /// Represents the Services in the application.
    /// </summary>
    [Table("services")]
    public class Services
    {
        /// <summary>
        /// Gets or sets the unique identifier for the service.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the description of the service.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the service.
        /// </summary>
        public Guid CreatedByUserId { get; set; }
    }
}
