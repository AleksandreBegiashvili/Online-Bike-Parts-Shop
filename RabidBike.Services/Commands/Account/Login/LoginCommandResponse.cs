using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Commands.Account.Login
{
    public class LoginCommandResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserId { get; set; }

        public string Error { get; set; }
    }
}
