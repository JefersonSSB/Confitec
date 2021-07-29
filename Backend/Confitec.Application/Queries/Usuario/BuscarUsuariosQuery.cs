using Confitec.Application.ValueObjects.Usuario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.Usuario
{
    public class BuscarUsuariosQuery : IRequest<List<UsuarioVO>>
    {
    }
}
