// <copyright file="AssociateDTO.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.DataAccess.Entities;

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the data transfer object for an associate.
    /// </summary>
    public class AssociateDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the associate.
        /// </summary>
        public int AssociateId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the customer associated with the associate.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the associate.
        /// </summary>
        public string AssociateName { get; set; }

        /// <summary>
        /// Gets or sets the Contact of the associate.
        /// </summary>
        public string ContactInformation { get; set; }

        /// <summary>
        /// Gets or sets of the DateTime of update.
        /// </summary>
        public Guid UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Roles of the associate.
        /// </summary>
        public Roles Roles { get; set; }
    }
}
