using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RabidBike.Data.Identity;
using RabidBike.Domain.Entities;
using RabidBike.Services.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Commands.Account.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly JwtSettings _jwtSettings;
        private readonly RabidUserManager _userManager;

        public LoginCommandHandler(IOptions<JwtSettings> jwtSettings,
                                    RabidUserManager userManager)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
            var tokenExpiryTime = Convert.ToDouble(_jwtSettings.ExpireTime);


            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var tokenHanlder = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, request.Email),
                    new Claim("LoggedOn", DateTime.Now.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                    new Claim("Id", user.Id)
                }),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _jwtSettings.Site,
                    Audience = _jwtSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };

                var token = tokenHanlder.CreateToken(tokenDescriptor);

                return new LoginCommandResponse
                {
                    Message = $"User {user.UserName} was successfully logged in",
                    Token = tokenHanlder.WriteToken(token),
                    Expiration = token.ValidTo,
                    UserName = user.UserName,
                    UserRole = roles.FirstOrDefault(),
                    UserId = user.Id,
                    Error = null
                };
            }

            return new LoginCommandResponse
            {
                Error = "Email/Password is wrong"
            };


        }
    }
}
