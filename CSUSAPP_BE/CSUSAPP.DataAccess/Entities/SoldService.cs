// <copyright file="SoldService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSUSAPP.DataAccess.Entities
{
    /// <summary>
    /// Represents the Sold details in the application.
    /// </summary>
    [Table("sold_services")]
    public class SoldService
    {
        /// <summary>
        ///  Gets or sets the unique identifier for the SoldService.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Service Name for the SoldService.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the SoldService.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the SoldService.
        /// </summary>
        public ServiceStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the SoldService.
        /// </summary>
        public Guid UpdatedBy { get; set; }

        // Foreign Key

        /// <summary>
        /// Gets or sets the unique identifier for the SoldService.
        /// </summary>
        public long CustomerDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the SoldService.
        /// </summary>
        public CustomerDetails CustomerDetails { get; set; }
    }

    /// <summary>
    /// Represents the Service Status details in the application.
    /// </summary>
    public enum ServiceStatus
    {
        Active,
        Inactive
    }
}
