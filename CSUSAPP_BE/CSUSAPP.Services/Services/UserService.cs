using CSUSAPP.Common.DTO;
using CSUSAPP.Common.Helpers;
using CSUSAPP.DataAccess.DataContext;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Services.Services
{
    public class UserService : IUserService
    {
        private readonly AppDataContext _appDataContext;
        public UserService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        public async Task<ApiResponse> CreateUser(CreateUserRequest request)
        {
            var response = new ApiResponse();
            try
            {
                if (request == null) throw new ArgumentNullException();
                var userEmailCheck = await _appDataContext.UsersData.Where(x => x.userEMailId == request.userEMailId).Select(x => x.userEMailId).FirstOrDefaultAsync();

                //var emailVerificationCheck = await _otpRepository.Find().Where(x => x.Email == request.userEMailId).FirstOrDefaultAsync();
                if (!string.IsNullOrEmpty(userEmailCheck))
                {
                    throw new Exception("User with this EmailId is already generated. please sign in.");
                }
                //if (emailVerificationCheck == null)
                //{
                //    throw new Exception("Email UserId is not verified.");
                //}
                else
                {
                    if (request.userEMailId.IsNullOrEmpty() || request.firstName.IsNullOrEmpty() || request.lastName.IsNullOrEmpty())
                    {
                        throw new Exception("Please enter all the details.");
                    }
                    var newUser = new UsersData();
                    
                    newUser.firstName = request.firstName;
                    newUser.lastName = request.lastName;
                    newUser.userEMailId = request.userEMailId;
                    newUser.roles = request.roles;
                    var cu = new PasswordHashingService();
                    var salt = cu.GenerateSalt();
                    var strPwd = cu.HashPassword(request.password, salt);

                    newUser.password = strPwd;
                    newUser.salt = salt;
                    _appDataContext.UsersData.Add(newUser);
                    await _appDataContext.SaveChangesAsync();


                    var newLogin = new LoginDetails();
                    newLogin.EmailId = request.userEMailId;
                    newLogin.Status = LoginStatus.pending;
                    _appDataContext.LoginDetails.Add(newLogin);
                    await _appDataContext.SaveChangesAsync();
                    response.Statuscode = (Convert.ToInt32(HttpStatusCode.OK));
                    response.Success = true;
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw ex;
                //response.Statuscode = (Convert.ToInt32(HttpStatusCode.InternalServerError));
                //response.Data = request;
                //response.Success = false;
                //response.Message = ex.Message;
            }
            return response;
        }
    }
}
