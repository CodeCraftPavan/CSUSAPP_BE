using CSUSAPP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.DTO
{
    public class CreateUserRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Roles roles { get; set; }
        public string userEMailId { get; set; }
        public string password { get; set; }
    }
}
