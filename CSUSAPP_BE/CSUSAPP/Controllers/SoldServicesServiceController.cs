using CSUSAPP.Common.Auth;
using CSUSAPP.Common.Helpers;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using CSUSAPP.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSUSAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldServicesServiceController : ControllerBase
    {
        private readonly ISoldServicesService _soldServicesService;
        private readonly IAuthUser _authUser;
        public SoldServicesServiceController(ISoldServicesService soldServicesService, IAuthUser authUser)
        {
            _soldServicesService = soldServicesService;
            _authUser = authUser;
        }

        [HttpPost("Add-Sold-Service")]
        [Authorize]
        public async Task<object> AddServiceToCustomer(SoldServiceDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _soldServicesService.AddSoldServices(request, userId);
            return result;
        }

        [HttpPost("Edit-Sold-Service")]
        [Authorize]
        public async Task<object> EditServiceToCustomer(SoldServiceDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _soldServicesService.EditSoldServices(request, userId);
            return result;
        }
    }
}
