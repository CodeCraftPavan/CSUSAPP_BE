using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CSUSAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
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
                return StatusCode((Convert.ToInt32(HttpStatusCode.InternalServerError)), response);
            }

            return result;
        }
    }
}
