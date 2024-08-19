using DevFreela.Application.Models;
using DevFreela.InfraSctructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Aplication.Querys.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ResultViewModel<ProjectViewModel>>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
