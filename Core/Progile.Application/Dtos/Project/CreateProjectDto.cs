namespace Progile.Application.Dtos.Project
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TeamId { get; set; }
    }
}
