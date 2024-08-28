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
    public class AssociatesController : ControllerBase
    {
        private IAssociateService _associateService;
        private readonly IAuthUser _authUser;
        public AssociatesController(IAssociateService associateService, IAuthUser authUser)
        {
            _associateService = associateService;
            _authUser = authUser;
        }

        [HttpPost("Add-Associates")]
        [Authorize]
        public async Task<object> AddServiceToCustomer(AssociateDTO request)
        {
            var userId = _authUser.Identity.UserId;
            var result = await _associateService.AddAssociatesServices(request, userId);
            return result;
        }

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
