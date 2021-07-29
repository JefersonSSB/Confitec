using Confitec.Application.Queries;
using Confitec.Application.ValueObjects.Usuario;
using Confitec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Confitec.Services.Handlers
{
    public class BuscarUsuarioPorIdHandler : IRequestHandler<BuscarUsuarioPorIdQuery, UsuarioVO>
    {

        private readonly ApplicationContext _context;

        public BuscarUsuarioPorIdHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UsuarioVO> Handle(BuscarUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {


            return await _context.Usuario
                .Include(x => x.Escolaridade)
                .Where(x => x.Id == request.Id)
                .Select(x => new UsuarioVO
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Sobrenome = x.Sobrenome,
                    Email = x.Email,
                    DataNascimento = x.DataNascimento,
                    Escolaridade = x.Escolaridade.Descricao,
                    EscolaridadeId = x.Escolaridade.Id
                }).FirstOrDefaultAsync();
        }
    }
}