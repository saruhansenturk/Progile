using Progile.Application.Dtos.User;
using Progile.Application.Response;

namespace Progile.Application.Abstraction.Services
{
    public interface IUserService<T>
    {
        Task<CommonResponse<bool>> CreateAsync(CreateUserDto createUserDto);
    }
}
