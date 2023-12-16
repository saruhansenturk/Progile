using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Application.Dtos.User;
using Progile.Application.Response;

namespace Progile.Application.Abstraction.Services
{
    public interface IUserService<T>
    {
        Task<CommonResponse<bool>> CreateAsync(CreateUserDto createUserDto);
    }
}
