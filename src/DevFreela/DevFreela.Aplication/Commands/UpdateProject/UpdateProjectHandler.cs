using DevFreela.Application.Models;
using DevFreela.InfraSctructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Aplication.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public UpdateProjectHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.IdProject);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não Existe");
            }

            project.Update(request.Title, request.Description, request.TotalCost);

            return ResultViewModel.Success();
        }
    }
}
