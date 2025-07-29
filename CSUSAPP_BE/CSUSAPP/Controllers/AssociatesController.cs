// <copyright file="AssociatesController.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.Auth;
using CSUSAPP.Common.Helpers;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    /// <summary>
    /// Controller for managing associates operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssociatesController : ControllerBase
    {
        private readonly IAuthUser _authUser;
        private IAssociateService _associateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociatesController"/> class.
        /// </summary>
        /// <param name="associateService">associateService.</param>
        /// <param name="authUser">authUser.</param>
        public AssociatesController(IAssociateService associateService, IAuthUser authUser)
        {
            _associateService = associateService;
            _authUser = authUser;
        }

        /// <summary>
        /// Adds a new associate service for a customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Add-Associates")]
        [Authorize]
        public async Task<object> AddServiceToCustomer(AssociateDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _associateService.AddAssociatesServices(request, userId);
            return result;
        }

        /// <summary>
        /// Edits an existing associate service for a customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Edit-Associates")]
        [Authorize]
        public async Task<object> EditServiceToCustomer(AssociateDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _associateService.EditAssociatesServices(request, userId);
            return result;
        }
    }
}
