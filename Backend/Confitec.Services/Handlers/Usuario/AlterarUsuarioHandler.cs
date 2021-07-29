using Confitec.Application.Commands.Usuario;
using Confitec.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Confitec.Domain.Entities;
using Confitec.Domain.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace Confitec.Services.Handlers
{
    public class AlterarUsuarioHandler : IRequestHandler<AlterarUsuarioCommand,Unit>
    {

        private readonly ApplicationContext _context;

        public AlterarUsuarioHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
   
            var escolaridade = await _context.Escolaridade
                .Where(x => x.Id == request.EscolaridadeId)
                .FirstOrDefaultAsync();
            var usuario = await _context.Usuario
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            usuario.Alterar(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, escolaridade);

            _context.Update(usuario);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
