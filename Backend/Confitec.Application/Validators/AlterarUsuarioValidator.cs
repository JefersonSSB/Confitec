using Confitec.Application.Commands.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Application.Validators
{
    public class AlterarUsuarioValidator : AbstractValidator<AlterarUsuarioCommand>
    {
        public AlterarUsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é Obrigatorio!")
                .MaximumLength(50).WithMessage("Número máximo de 50 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Sobrenome é Obrigatorio!")
                .MaximumLength(100).WithMessage("Número máximo de 100 caracteres");

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Email Invalido");

            RuleFor(c => c.DataNascimento).NotEmpty().WithMessage("Data de Nascimento é Obrigatorio!")
                .LessThan(DateTime.Today).WithMessage("A data de nascimento não pode ser maior que a data a atual."); 

            RuleFor(c => c.EscolaridadeId)
                .GreaterThan(0).WithMessage("Escolaridade é Obrigatorio!");

        }
    }
}
