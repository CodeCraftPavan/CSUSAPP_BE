// <copyright file="UsersController.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using System.Net;
using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    /// <summary>
    /// Controller for managing user operations such as creating users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">userService.</param>
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Create-User")]
        public async Task<object> Createuser(CreateUserRequest request)
        {
            var result = await _userService.CreateUser(request);
            var response = new ApiResponse();
            if (!result.Success)
            {
                response.Statuscode = result.Statuscode;
                response.Success = result.Success;
                response.Message = result.Message;
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }

            return result;
        }
    }
}
