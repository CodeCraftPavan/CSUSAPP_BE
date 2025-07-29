// <copyright file="AddServiceServicesController.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

namespace CSUSAPP.API.Controllers
{
    using CSUSAPP.Common.Auth;
    using CSUSAPP.Common.Helpers;
    using CSUSAPP.Services.DTO;
    using CSUSAPP.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for managing add services operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AddServiceServicesController : ControllerBase
    {
        private readonly IAddServicesService _addServicesService;
        private readonly IAuthUser _authUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceServicesController"/> class.
        /// </summary>
        /// <param name="addServicesService">addServicesService.</param>
        /// <param name="authUser">authUser.</param>
        public AddServiceServicesController(IAddServicesService addServicesService, IAuthUser authUser)
        {
            _addServicesService = addServicesService;
            _authUser = authUser;
        }

        /// <summary>
        /// Adds a new service for a customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Add-Services")]
        [Authorize]
        public async Task<IActionResult> EditCustomer([FromBody] AddServiceDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _addServicesService.AddServices(request, userId);
            return Ok(result);
        }

        /// <summary>
        /// Gets the available services for a customer.
        /// </summary>
        /// <param name="customerId">customerId.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Get-Available-Services")]
        [Authorize]
        public async Task<IActionResult> GetAvailableServicesForCustomers([FromBody] long customerId)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _addServicesService.GetAvailableServicesForCustomers(customerId);
            return Ok(result);
        }
    }
}
