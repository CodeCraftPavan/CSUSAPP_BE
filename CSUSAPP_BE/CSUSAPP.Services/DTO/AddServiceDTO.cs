// <copyright file="AddServiceDTO.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.Services.DTO
{
    /// <summary>
    /// Represents the Data Transfer Object for adding a new service.
    /// </summary>
    public class AddServiceDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the service.
        /// </summary>
        public string ServiceName { get; set; }
    }
}
