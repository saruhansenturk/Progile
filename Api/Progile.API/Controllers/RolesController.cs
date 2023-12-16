using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Progile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<CommonResponse<CreateRoleDto>> CreateProject(CreateRoleCommandRequest request)
        //{
        //    CommonResponse<CreateRoleDto> response = await _mediator.Send(request);
        //    return response;
        //}
        
        //[HttpPost("[action]")]
        //public async Task<CommonResponse<bool>> Delete(DeleteRoleCommandRequest request)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(request);
        //    return response;
        //}
        
        //[HttpGet("[action]")]
        //public async Task<CommonResponse<List<RoleGetAllByTeamDto>>> ByTeamId(RoleGetAllByTeamQueryRequest request)
        //{
        //    CommonResponse<List<RoleGetAllByTeamDto>> response = await _mediator.Send(request);
        //    return response;
        //}

    

    }
}
