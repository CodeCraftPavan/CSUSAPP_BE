// <copyright file="IAddServicesService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;

namespace CSUSAPP.Services.Interfaces
{
    /// <summary>
    /// Interface for AddServices Service.
    /// </summary>
    public interface IAddServicesService
    {
        /// <summary>
        /// Add Services.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="userId">userId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> AddServices(AddServiceDTO request, Guid userId);

        /// <summary>
        /// Get Available Services.
        /// </summary>
        /// <param name="customerId">customerId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> GetAvailableServicesForCustomers(long customerId);
    }
}
