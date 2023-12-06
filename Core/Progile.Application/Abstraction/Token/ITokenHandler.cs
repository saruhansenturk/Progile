using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progile.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        string CreateAccessToken(int second);
    }
}
