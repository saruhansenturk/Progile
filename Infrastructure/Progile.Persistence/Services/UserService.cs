using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Progile.Application.Abstraction.Services;
using Progile.Application.Dtos.User;
using Progile.Application.Response;
using Progile.Domain.Entities;

namespace Progile.Persistence.Services
{
    public class UserService<T> : IUserService<T>
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommonResponse<bool>> CreateAsync(CreateUserDto createUserDto)
        {
            if (!string.Equals(createUserDto.Password, createUserDto.PasswordConfirm))
                return new CommonResponse<bool>
                {
                    Data = false,
                    ResponseStatus = ResponseStatus.Info,
                    Message = "Your password and password confirm fields does not matched!"
                };

            IdentityResult result = await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
            }, createUserDto.Password);

            CommonResponse<bool> response = new()
            {
                ResponseStatus = result.Succeeded ? ResponseStatus.Success : ResponseStatus.Fail
            };

            if (result.Succeeded)
                response.Message = "The user has been created successful";
            else
                result.Errors.ToList().ForEach(error =>
                {
                    response.Errors.Add($"{error.Code} - {error.Description}");
                });

            return response;
        }
    }
}
