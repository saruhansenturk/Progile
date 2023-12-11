using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progile.Application.Dtos.Task;
using Progile.Application.Features.Commands.TaskCommands.CreateTaskHandler;
using Progile.Application.Features.Queries.TaskQueries.GetTaskByProjectQuery;
using Progile.Application.Paging;
using Progile.Application.Response;

namespace Progile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommonResponse<CreateTaskDto>> CreateTask(CreateTaskCommandRequest request)
        {
            CommonResponse<CreateTaskDto> response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("[action]")]
        public async Task<CommonResponse<Pagination<AllTaskByProjectIdDtos>>> GetAllTaskByProject(
            GetAllTaskByProjectIdQueryRequest request)
        {
            CommonResponse<Pagination<AllTaskByProjectIdDtos>> response = await _mediator.Send(request);
            return response;
        }

        //[HttpPost("[action]")]
        //public async Task<CommonResponse<bool>> UpdateTask([FromBody] UpdateTaskCommandRequest request)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(request);
        //    return response;
        //}


        //[HttpPost("[action]")]
        //public async Task<CommonResponse<Pagination<GetAllTaskDto>>> GetAllTask([FromBody] GetAllTaskQueryRequest request)
        //{
        //    CommonResponse<Pagination<GetAllTaskDto>> response = await _mediator.Send(request);
        //    return response;
        //}


        //[HttpGet("[action]")]
        //public async Task<CommonResponse<GetByIdTaskDto>> GetTask([FromQuery] GetByIdTaskQueryRequest request)
        //{
        //    CommonResponse<GetByIdTaskDto> response = await _mediator.Send(request);
        //    return response;
        //}



        //[HttpPost("[action]")]
        //public async Task<CommonResponse<bool>> Delete([FromQuery] DeleteTaskCommandRequest request)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(request);
        //    return response;
        //}

    }
}
