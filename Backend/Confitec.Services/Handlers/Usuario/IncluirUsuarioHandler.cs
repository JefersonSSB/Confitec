using Confitec.Application.Commands.Usuario;
using Confitec.Infrastructure.Context;
using MediatR;
using Confitec.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Services.Handlers

{
    public class IncluirUsuarioHandler : IRequestHandler<IncluirUsuarioCommand, Unit>
    {

        private readonly ApplicationContext _context;

        public IncluirUsuarioHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(IncluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            var escolaridade = await _context
                .Escolaridade.Where(x => x.Id == request.EscolaridadeId)
                .FirstOrDefaultAsync();


            var usuario = new Usuario(
                request.Nome,
                request.Sobrenome,
                request.Email,
                request.DataNascimento);

            usuario.setEscolaridade(escolaridade);

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
