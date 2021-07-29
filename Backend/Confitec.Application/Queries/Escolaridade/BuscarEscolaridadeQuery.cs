using Confitec.Application.ValueObjects.Escolaridade;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Application.Queries
{
    public class BuscarEscolaridadeQuery : IRequest<List<EscolaridadeVO>>
    {

    }
}
