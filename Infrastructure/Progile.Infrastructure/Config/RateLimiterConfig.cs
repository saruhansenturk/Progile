using Progile.Application.Abstraction.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progile.Infrastructure.Config
{
    public class RateLimiterConfig: IRateLimiterConfig
    {
        public int PermitLimit { get; set; }
        public int Window { get; set; }
        public string QueueProcessingOrder { get; set; }
        public int QueueLimit { get; set; }
    }
}
