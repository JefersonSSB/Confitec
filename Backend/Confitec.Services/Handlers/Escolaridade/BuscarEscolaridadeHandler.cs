using Confitec.Application.Queries;
using Confitec.Application.ValueObjects.Escolaridade;
using Confitec.Infrastructure.Context;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers.Escolaridade
{
    public class BuscarEscolaridadeHandler : IRequestHandler<BuscarEscolaridadeQuery, List<EscolaridadeVO>>
    {
        private readonly ApplicationContext _context;

        public BuscarEscolaridadeHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<EscolaridadeVO>> Handle(BuscarEscolaridadeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Escolaridade.
                Select(x => new EscolaridadeVO
                { Id = x.Id, Descricao = x.Descricao }).ToListAsync();
        }
    }

}
