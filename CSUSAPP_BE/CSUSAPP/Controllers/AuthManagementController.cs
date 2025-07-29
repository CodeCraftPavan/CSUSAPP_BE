// <copyright file="AuthManagementController.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    /// <summary>
    /// Controller for managing authentication operations such as user sign-in.
    /// </summary>
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly IAuthmanagementService _authmanagementService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthManagementController"/> class.
        /// </summary>
        /// <param name="authmanagementService">authmanagementService.</param>
        public AuthManagementController(IAuthmanagementService authmanagementService)
        {
            _authmanagementService = authmanagementService;
        }

        /// <summary>
        /// Handles user sign-in requests.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Sign-In")]
        public async Task<object> SignIn(LoginRequest request)
        {
            var result = await _authmanagementService.SignInUser(request);
            return result;
        }
    }
}
