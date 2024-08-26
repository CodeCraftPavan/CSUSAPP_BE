using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CSUSAPP.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly IAuthmanagementService _authmanagementService;

        public AuthManagementController(IAuthmanagementService authmanagementService)
        {
            _authmanagementService = authmanagementService;
            
        }



        [HttpPost("Sign-In")]
        public async Task<object> SignIn(LoginRequest request)
        {
            var result = await _authmanagementService.SignInUser(request);
            return result;
        }
    }
}
