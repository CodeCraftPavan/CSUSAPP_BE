using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Common.Auth
{
    public class AuthUser : IAuthUser
    {
        public AuthUser() { }
        public UserIdentity Identity { get; init; }
        public bool IsAuthenticated => Identity != null;
        public AuthUser(HttpContext context)
        {

            var authUserId = context.Items["userId"];

            Console.WriteLine("Auth user is being set here: userId is " + authUserId);

            if (authUserId != null)
            {
                Identity = new UserIdentity
                {
                    UserId = (Guid)authUserId
                };
            }

            string authUserRole = (string)context.Items["userRole"];
            string method = (string)context.Items["method"];

            //Log.Information("authUserRole is " + authUserRole);

            if (authUserRole != null)
            {
                var roles = authUserRole.Split(',');

                var userRoles = new List<string>();

                foreach (var r in roles)
                {
                    //var userRole = string.IsNullOrEmpty(r) ? UserRole.guest : ResolveEnumMember.FromString<UserRole>(r);
                    userRoles.Add(r);
                }

                Identity.UserRoles = userRoles;
            }
        }
    }
    public class UserIdentity
    {
        public Guid UserId { get; set; }
        public List<string> UserRoles { get; set; }
        public string SessionToken { get; set; }
    }
    public interface IAuthUser
    {
        bool IsAuthenticated { get; }
        UserIdentity Identity { get; init; }
    }
}
