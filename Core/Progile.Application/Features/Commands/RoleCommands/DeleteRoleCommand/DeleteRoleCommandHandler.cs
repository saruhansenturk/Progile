using MediatR;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.RoleCommands.DeleteRoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, CommonResponse<bool>>
    {
        private readonly IRoleWriteRepository _roleWriteRepository;

        public DeleteRoleCommandHandler(IRoleWriteRepository roleWriteRepository)
        {
            _roleWriteRepository = roleWriteRepository;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await _roleWriteRepository.RemoveAsync(request.Id);

            if (isDeleted)
            {
                var saveChanges = await _roleWriteRepository.SaveAsync();
                if (saveChanges.Data == 1)
                {
                    return new CommonResponse<bool>
                    {
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Role successfully deleted!"
                    };
                }

                return new CommonResponse<bool>
                {
                    Message = "An error occurred while executing the delete command!",
                    ResponseStatus = ResponseStatus.Fail
                };
            }

            return new CommonResponse<bool>
            {
                Message = "There is no role for this id.",
                ResponseStatus = ResponseStatus.Fail
            };
        }
    }

    public class DeleteRoleCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string Id { get; set; }
    }
}