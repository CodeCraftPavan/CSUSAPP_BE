// <copyright file="CustomerController.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.Auth;
using CSUSAPP.Common.DTO;
using CSUSAPP.Common.Helpers;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    /// <summary>
    /// Controller for managing customer operations such as adding, editing, and retrieving customers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAuthUser _authUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">customerService.</param>
        /// <param name="authUser">authUser.</param>
        public CustomerController(ICustomerService customerService, IAuthUser authUser)
        {
            _customerService = customerService;
            _authUser = authUser;
        }

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Add-Customer")]
        [Authorize]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDetailsDto request)
        {
            var result = await _customerService.AddCustomer(request);
            return Ok(result);
        }

        /// <summary>
        /// Edits an existing customer.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns>It returns API response.</returns>
        [HttpPost("Edit-Customer")]
        [Authorize]
        public async Task<IActionResult> EditCustomer([FromBody] EditCustomerDto request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _customerService.EditCustomer(request, userId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated list of customers.
        /// </summary>
        /// <param name="pagination">pagination.</param>
        /// <returns>Paginated Get Customers.</returns>
        [HttpPost("Get-Customers")]
        [Authorize]
        public async Task<IActionResult> GetCustomer([FromBody] PaginationDTO pagination)
        {
            var result = await _customerService.GetCustomers(pagination);
            return Ok(result);
        }

        /// <summary>
        /// Searches for customers based on a search term.
        /// </summary>
        /// <param name="searchTearm">searchTearm.</param>
        /// <returns>It returns CustomerDetailsDto.</returns>
        [HttpPost("Search-Customers")]
        [Authorize]
        public async Task<IActionResult> SearchCustomer([FromBody] string searchTearm)
        {
            var result = await _customerService.SearchCustomers(searchTearm);
            return Ok(result);
        }
    }
}
