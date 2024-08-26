using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.DTO
{
    public class LoginRequest
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }

    public class AuthUserResponse
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string token { get; set; }
    }
}
