using Confitec.Application.Commands.Usuario;
using Confitec.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Services.Handlers
{
    public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioCommand, Unit>
    {

        private readonly ApplicationContext _context;

        public DeletarUsuarioHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {

            var usuario = await _context.Usuario
                     .Where(x => x.Id == request.Id)
                     .FirstOrDefaultAsync();

            _context.Usuario.Remove(usuario);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
    
