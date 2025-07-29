// <copyright file="SoldServiceDTO.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.DataAccess.Entities;

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the data transfer object for a sold service.
    /// </summary>
    public class SoldServiceDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sold service.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the id of the service.
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the date when the service was sold.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the sold service.
        /// </summary>
        public ServiceStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the data transfer object for editing a sold service.
    /// </summary>
    public class EditSoldServiceDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sold service.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the id of the service.
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the status of the sold service.
        /// </summary>
        public ServiceStatus Status { get; set; }
    }
}