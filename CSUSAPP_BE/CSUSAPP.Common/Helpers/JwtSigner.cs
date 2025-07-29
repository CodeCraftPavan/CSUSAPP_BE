// <copyright file="JwtSigner.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSUSAPP.Common.Helpers
{
    /// <summary>
    /// Represents a JWT signer that generates JSON Web Tokens (JWT) for user authentication.
    /// </summary>
    public class JwtSigner
    {
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtSigner"/> class with the specified application settings.
        /// </summary>
        /// <param name="appSettings">appSettings.</param>
        public JwtSigner(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Generates a JSON Web Token (JWT) for the specified user ID and roles.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="roles">roles.</param>
        /// <param name="method">method.</param>
        /// <returns>It returns JWT Token.</returns>
        public string GenerateJwtToken(string userId, List<string> roles, string method = "webApplication")
        {
            var rolesCSV = string.Join(",", roles);

            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId), new Claim("role", rolesCSV), new Claim("method", method) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
