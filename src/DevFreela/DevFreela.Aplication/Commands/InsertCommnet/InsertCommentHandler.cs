using DevFreela.Application.Models;
using DevFreela.Core.Entitiees;
using DevFreela.Core.Repositories;
using DevFreela.InfraSctructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.InsertCommnet
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _projectRepository;
        public InsertCommentHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.IdProject);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não Existe");
            }

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            return ResultViewModel.Success();
        }
    }
}
