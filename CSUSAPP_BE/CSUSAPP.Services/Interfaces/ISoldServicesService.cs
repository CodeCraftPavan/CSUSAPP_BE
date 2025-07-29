// <copyright file="ISoldServicesService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;

namespace CSUSAPP.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISoldServicesService
    {
        /// <summary>
        /// Add Sold Services.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="userId">userId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> AddSoldServices(SoldServiceDTO request, Guid userId);

        /// <summary>
        /// Edit Sold Services.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="userId">userId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> EditSoldServices(SoldServiceDTO request, Guid userId);
    }
}
