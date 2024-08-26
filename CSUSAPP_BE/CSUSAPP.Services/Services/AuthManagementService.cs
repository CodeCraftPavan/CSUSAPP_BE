using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CSUSAPP.Common.Helpers;
using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using System.Text;
using System.Threading.Tasks;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CSUSAPP.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CSUSAPP.Services.Services
{
    public class AuthManagementService : IAuthmanagementService
    {
        private readonly AppDataContext _appDataContext;
        private readonly JwtSigner _jwtSigner;
        
        public AuthManagementService(AppDataContext appDataContext, JwtSigner jwtSigner) 
        {
            _appDataContext = appDataContext;
            _jwtSigner = jwtSigner;
        }
        

        public async Task<ApiResponse> SignInUser(LoginRequest request)
        {
            var response = new ApiResponse();
            var sessionToken = string.Empty;
            var msg = string.Empty;
            try
            {
                if (request.UserEmail.IsNullOrEmpty() || request.Password.IsNullOrEmpty())
                {
                    throw new ArgumentNullException("UserName or password has not entered");
                }
                else
                {
                    var UserDetails = await _appDataContext.UsersData.Where(x => x.userEMailId == request.UserEmail).FirstOrDefaultAsync();

                    if (UserDetails == null)
                    {
                        msg = "Entered email ID is not registered, Please Sign up.";
                        throw new ValidationException(msg);
                    }
                    if (UserDetails.password != null)
                    {
                        var cu = new PasswordHashingService();
                        bool pwdCheck = cu.VerifyPassword(request.Password, UserDetails.password, UserDetails.salt);
                        if (pwdCheck == true)
                        {
                            msg = "Authentication completed sucessfully.";
                        }
                        else
                        {
                            msg = "Authentication failed. Please enter the right password.";
                            throw new ValidationException(msg);

                        }
                    }

                    var login = await _appDataContext.LoginDetails.Where(x => x.EmailId == request.UserEmail /*x.Status == LoginStatus.pending*/).FirstOrDefaultAsync();
                    //if (login == null)
                    //{
                    //    msg = "User is already logged in.";
                    //    throw new ValidationException(msg);
                    //}
                    //else
                    //{
                        var userData = await _appDataContext.UsersData.Where(x => x.userEMailId == request.UserEmail).FirstOrDefaultAsync();
                        sessionToken = _jwtSigner.GenerateJwtToken(userData.UserId.ToString(), new List<string> { "User" });                        
                        login.SessionToken = sessionToken;
                        login.Status = LoginStatus.completed;
                        login.LoggedInAt = DateTime.Now;
                        _appDataContext.Update(login);
                        await _appDataContext.SaveChangesAsync();
                        var res = new AuthUserResponse
                        {
                            firstName = userData.firstName,
                            lastName = userData.lastName,
                            token = sessionToken
                        };
                        //response.Statuscode = (Convert.ToInt32(HttpStatusCode.OK));
                        response.Data = res;
                        //response.Success = true;
                        return response;

                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //response.Statuscode = (Convert.ToInt32(HttpStatusCode.InternalServerError));
                //response.Success = false;
                //response.Message = ex.Message;
            }
            return response;
        }
    }
}
