using DevFreela.Aplication.Commands.Projects.InsertProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Validator
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage("Não pode sewr vazio")
                .MaximumLength(50)
                    .WithMessage("Tamanho maximo é 50 caracteres");

            RuleFor(p => p.TotalCost)
                .GreaterThanOrEqualTo(1000)
                    .WithMessage("O projeto deve custar pelo menos R$1.000");
        }
    }
}
