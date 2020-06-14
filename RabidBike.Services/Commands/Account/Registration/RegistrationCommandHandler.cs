using MediatR;
using Microsoft.AspNetCore.Identity;
using RabidBike.Data.Identity;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Commands.Account.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationCommandResponse>
    {
        private readonly RabidUserManager _userManager;

        public RegistrationCommandHandler(RabidUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegistrationCommandResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationCommandResponse { Username = user.UserName, Email = user.Email };
            }

            return null;
        }
    }
}
