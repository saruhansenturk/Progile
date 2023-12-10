using MediatR;
using Progile.Application.Dtos.Task;
using Progile.Application.Extensions;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Enums;
using Task = Progile.Domain.Entities.Task;

namespace Progile.Application.Features.Commands.TaskCommands.CreateTaskHandler
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommandRequest, CommonResponse<CreateTaskDto>>
    {
        private readonly ITaskWriteRepository _taskWriteRepository;

        public CreateTaskCommandHandler(ITaskWriteRepository taskWriteRepository)
        {
            _taskWriteRepository = taskWriteRepository;
        }

        public async Task<CommonResponse<CreateTaskDto>> Handle(CreateTaskCommandRequest request, CancellationToken cancellationToken)
        {
            // todo global olarak insert update cross cutting alanlar db ye eklenecek!
            //var task = request.MapTo<Task>();

            //if (task != null)
            //{
            //var createdTask = await _taskWriteRepository.AddAsync(task);

            var createdTask = await _taskWriteRepository.AddAsync(new Task
            {
                Name = request.Name,
                Description = request.Description,
                IsDeleted = false,
                Creator = "Saruhan",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDone = false,
                ModifiedDate = DateTime.Now.AddDays(2),
                Modifier = "Saruhan",
                EndDate = DateTime.Now.AddDays(10),
                IsCanceled = false,
                IsLimited = true,
                StartDate = DateTime.Now.AddDays(-2),
                UrgentStatus = request.UrgentStatus,
                Title = request.Title,
                ProjectId = request.ProjectId,
            });
            var saveChanges = await _taskWriteRepository.SaveAsync();

            if (saveChanges.Data == 1)
                return new CommonResponse<CreateTaskDto>
                {
                    Data = createdTask.Data.MapTo<CreateTaskDto>(),
                    ResponseStatus = ResponseStatus.Success
                };
            //}

            return new CommonResponse<CreateTaskDto>
            {
                Data = null,
                ResponseStatus = ResponseStatus.Fail,
                Message = "An error occured when insert to data!"
            };
        }
    }

    public class CreateTaskCommandRequest : IRequest<CommonResponse<CreateTaskDto>>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsLimited { get; set; }
        public UrgentStatus UrgentStatus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsCanceled { get; set; }

        public Guid ProjectId { get; set; }
    }
}
