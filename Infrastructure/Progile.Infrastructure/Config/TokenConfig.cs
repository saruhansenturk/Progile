﻿using Progile.Application.Abstraction.Token;

namespace Progile.Infrastructure.Config
{
    public class TokenConfig: ITokenConfig
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public int Expiration { get; set; }
    }

}
