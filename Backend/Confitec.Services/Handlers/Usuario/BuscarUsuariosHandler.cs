using Confitec.Application.Queries.Usuario;
using Confitec.Application.ValueObjects.Usuario;
using Confitec.Infrastructure.Context;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers
{
    public class BuscarUsuariosHandler : IRequestHandler<BuscarUsuariosQuery,List<UsuarioVO>>
    {
        private readonly ApplicationContext _context;

        public BuscarUsuariosHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioVO>> Handle(BuscarUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuario
               .Select(x => new UsuarioVO
               {
                   Id = x.Id,
                   Nome = x.Nome,
                   Sobrenome = x.Sobrenome,
                   Email = x.Email,
                   DataNascimento = x.DataNascimento,
                   Escolaridade = x.Escolaridade.Descricao,
                   EscolaridadeId = x.Escolaridade.Id
               }).ToListAsync();
        }
    }
}
