// <copyright file="UserService.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.Common.DTO;
using CSUSAPP.Common.Helpers;
using CSUSAPP.DataAccess.DataContext;
using CSUSAPP.DataAccess.Entities;
using CSUSAPP.Services.DTO;
using CSUSAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace CSUSAPP.Services.Services
{
    /// <summary>
    /// /// Implementation of the IUser Service..
    /// </summary>
    public class UserService : IUserService
    {
        private readonly AppDataContext _appDataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class with a specified role.
        /// </summary>
        /// <param name="appDataContext">appDataContext.</param>
        public UserService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CreateUser(CreateUserRequest request)
        {
            var response = new ApiResponse();
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException();
                }

                var userEmailCheck = await _appDataContext.UsersData.Where(x => x.UserEmailId == request.UserEmailId).Select(x => x.UserEmailId).FirstOrDefaultAsync();                
                if (!string.IsNullOrEmpty(userEmailCheck))
                {
                    throw new Exception("User with this EmailId is already generated. please sign in.");
                }
                else
                {
                    if (request.UserEmailId.IsNullOrEmpty() || request.FirstName.IsNullOrEmpty() || request.LastName.IsNullOrEmpty())
                    {
                        throw new Exception("Please enter all the details.");
                    }

                    var newUser = new UsersData();
                    newUser.FirstName = request.FirstName;
                    newUser.LastName = request.LastName;
                    newUser.UserEmailId = request.UserEmailId;
                    newUser.Roles = request.Roles;
                    var cu = new PasswordHashingService();
                    var salt = cu.GenerateSalt();
                    var strPwd = cu.HashPassword(request.Password, salt);

                    newUser.Password = strPwd;
                    newUser.Salt = salt;
                    _appDataContext.UsersData.Add(newUser);
                    await _appDataContext.SaveChangesAsync();
                    var newLogin = new LoginDetails();
                    newLogin.EmailId = request.UserEmailId;
                    newLogin.Status = LoginStatus.Pending;
                    _appDataContext.LoginDetails.Add(newLogin);
                    await _appDataContext.SaveChangesAsync();
                    response.Statuscode = Convert.ToInt32(HttpStatusCode.OK);
                    response.Success = true;
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
