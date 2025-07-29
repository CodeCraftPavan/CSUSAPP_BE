// <copyright file="IUserService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;

namespace CSUSAPP.Services.Interfaces
{
    /// <summary>
    /// Interface for User Service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Create User.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns ApiResponse.</returns>
        public Task<ApiResponse> CreateUser(CreateUserRequest request);
    }
}
