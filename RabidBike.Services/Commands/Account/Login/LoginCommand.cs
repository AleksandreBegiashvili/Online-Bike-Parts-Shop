using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Commands.Account.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
