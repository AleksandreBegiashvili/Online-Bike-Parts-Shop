using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Site { get; set; }
        public string Audience { get; set; }
        public string ExpireTime { get; set; }
    }
}
