using CSUSAPP.Common.Auth;
using CSUSAPP.Common.DTO;
using CSUSAPP.Common.Helpers;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAuthUser _authUser;
        public CustomerController(ICustomerService customerService, IAuthUser authUser) 
        {
            _customerService = customerService;
            _authUser = authUser;
        }

        [HttpPost("Add-Customer")]
        [Authorize]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDetailsDto request)
        {
            var result = await _customerService.AddCustomer(request);
            return Ok(result);
        }

        [HttpPost("Edit-Customer")]
        [Authorize]
        public async Task<IActionResult> EditCustomer([FromBody] EditCustomerDto request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _customerService.EditCustomer(request, userId);
            return Ok(result);
        }

        [HttpPost("Get-Customers")]
        [Authorize]
        public async Task<IActionResult> GetCustomer([FromBody] paginationDTO pagination)
        {
            var result = await _customerService.GetCustomers(pagination);
            return Ok(result);
        }

        [HttpPost("Search-Customers")]
        [Authorize]
        public async Task<IActionResult> SearchCustomer([FromBody] string searchTearm)
        {
            var result = await _customerService.SearchCustomers(searchTearm);
            return Ok(result);
        }
    }
}
