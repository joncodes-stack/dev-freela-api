using DevFreela.Aplication.Notification.ProjectCreated;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.InfraSctructure.Context;
using MediatR;

namespace DevFreela.Aplication.Commands.InsertProject
{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly IMediator _mediator;
        private readonly IProjectRepository _projectRepository;

        public InsertProjectHandler(IMediator mediator, IProjectRepository repository)
        {
            _mediator = mediator;
            _projectRepository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();
            
            await _projectRepository.Add(project);

            var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);
            await _mediator.Publish(projectCreated);

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}
