using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Aplication.Commands.InsertCommnet
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
