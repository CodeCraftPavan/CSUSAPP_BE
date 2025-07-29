// <copyright file="IAssociateService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;

namespace CSUSAPP.Services.Interfaces
{
    /// <summary>
    /// Interface for Associate Service.
    /// </summary>
    public interface IAssociateService
    {
        /// <summary>
        /// Add Associates Services.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="userId">userId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> AddAssociatesServices(AssociateDTO request, Guid userId);

        /// <summary>
        /// Edit Associates Services.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="userId">userId.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> EditAssociatesServices(AssociateDTO request, Guid userId);
    }
}
