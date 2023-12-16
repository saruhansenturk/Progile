//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using MediatR;
//using Progile.Application.Abstraction.Services;
//using Progile.Application.Dtos.Role;
//using Progile.Application.Extensions;
//using Progile.Application.Repositories;
//using Progile.Application.Response;
//using Progile.Domain.Entities;

//namespace Progile.Application.Features.Commands.RoleCommands.CreateRoleCommand
//{
//    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CommonResponse<CreateRoleDto>>
//    {
//        private readonly IRoleWriteRepository _roleWriteRepository;


//        public CreateRoleCommandHandler(IRoleWriteRepository roleWriteRepository)
//        {
//            _roleWriteRepository = roleWriteRepository;
//        }

//        public async Task<CommonResponse<CreateRoleDto>> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
//        {
//            var createdRole = await _roleWriteRepository.AddAsync(new Role
//            {
//                Name = request.Name,
//                TeamId = request.TeamId,
//                IsActive = true,
//                IsDeleted = false,
//                Creator = "Batug",
//                Modifier = "Batug",
//            });

//            var saveChanges = await _roleWriteRepository.SaveAsync();

//            if (saveChanges.Data == 1)
//            {
//                return new CommonResponse<CreateRoleDto>
//                {
//                    Data = createdRole?.Data?.MapTo<CreateRoleDto>(),
//                    ResponseStatus = ResponseStatus.Success,
//                    Message = "Role created for Team successfully!"
//                };
//            }

//            return new CommonResponse<CreateRoleDto>
//            {
//                Data = null,
//                ResponseStatus = ResponseStatus.Fail,
//                Message = "An error occurred when inserting data!"
//            };
//        }
//    }

//    public class CreateRoleCommandRequest : IRequest<CommonResponse<CreateRoleDto>>
//    {
//        public string Name { get; set; }
//        public Guid TeamId { get; set; }

//    }
//}
