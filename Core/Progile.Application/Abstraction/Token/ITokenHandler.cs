using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Application.Dtos.Token;

namespace Progile.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        LoginToken CreateAccessToken(int second);
    }
}
