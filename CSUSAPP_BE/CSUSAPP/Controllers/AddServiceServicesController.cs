using CSUSAPP.Common.Auth;
using CSUSAPP.Common.Helpers;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddServiceServicesController : ControllerBase
    {
        private readonly IAddServicesService _addServicesService;
        private readonly IAuthUser _authUser;
        public AddServiceServicesController(IAddServicesService addServicesService, IAuthUser authUser)
        {
            _addServicesService = addServicesService;
            _authUser = authUser;
        }

        [HttpPost("Add-Services")]
        [Authorize]
        public async Task<IActionResult> EditCustomer([FromBody] AddServiceDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _addServicesService.AddServices(request, userId);
            return Ok(result);
        }

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
