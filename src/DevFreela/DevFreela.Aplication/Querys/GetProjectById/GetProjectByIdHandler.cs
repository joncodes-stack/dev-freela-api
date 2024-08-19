using DevFreela.Application.Models;
using DevFreela.InfraSctructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Querys.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _context;
        public GetProjectByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (projects is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não Existe");
            }

            var model = ProjectViewModel.FromEntity(projects);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}
