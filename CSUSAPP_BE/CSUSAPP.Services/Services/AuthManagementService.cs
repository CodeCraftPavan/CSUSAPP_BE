// <copyright file="AuthManagementService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.Helpers;
using CSUSAPP.Common.DTO;
using CSUSAPP.Services.DTO;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CSUSAPP.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CSUSAPP.Services.Services
{
    /// <summary>
    /// Implementation of the IAuthManagement Service.
    /// </summary>
    public class AuthManagementService : IAuthmanagementService
    {
        private readonly AppDataContext _appDataContext;
        private readonly JwtSigner _jwtSigner;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthManagementService"/> class.
        /// </summary>
        /// <param name="appDataContext">appDataContext.</param>
        /// <param name="jwtSigner">jwtSigner.</param>

        public AuthManagementService(AppDataContext appDataContext, JwtSigner jwtSigner) 
        {
            _appDataContext = appDataContext;
            _jwtSigner = jwtSigner;
        }

        /// <inheritdoc/>
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
                    UsersData? userDetails = await _appDataContext.UsersData.Where(x => x.UserEmailId == request.UserEmail).FirstOrDefaultAsync();

                    if (userDetails == null)
                    {
                        msg = "Entered email ID is not registered, Please Sign up.";
                        throw new ValidationException(msg);
                    }

                    if (userDetails.Password != null)
                    {
                        var cu = new PasswordHashingService();
                        bool pwdCheck = cu.VerifyPassword(request.Password, userDetails.Password, userDetails.Salt);
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
                    var userData = await _appDataContext.UsersData.Where(x => x.UserEmailId == request.UserEmail).FirstOrDefaultAsync();
                    sessionToken = _jwtSigner.GenerateJwtToken(userData.UserId.ToString(), new List<string> { "User" });                        
                    login.SessionToken = sessionToken;
                    login.Status = LoginStatus.completed;
                    login.LoggedInAt = DateTime.Now;
                    _appDataContext.Update(login);
                    await _appDataContext.SaveChangesAsync();
                    var res = new AuthUserResponse
                    {
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        Token = sessionToken,
                    };
                    response.Data = res;
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
