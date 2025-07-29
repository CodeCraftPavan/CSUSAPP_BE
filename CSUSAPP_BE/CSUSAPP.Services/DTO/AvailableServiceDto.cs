// <copyright file="AvailableServiceDto.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the Data Transfer Object for available services.
    /// </summary>
    public class AvailableServiceDto
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
        /// Gets or sets the date when the service was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
