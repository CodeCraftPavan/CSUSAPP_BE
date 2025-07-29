// <copyright file="IAuthmanagementService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;

namespace CSUSAPP.Services.Interfaces
{
    /// <summary>
    /// Interface for Authmanagement Service.
    /// </summary>
    public interface IAuthmanagementService
    {
        /// <summary>
        /// User SignIn method.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> SignInUser(LoginRequest request);
    }
}
