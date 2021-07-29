using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.Usuario
{
    public class DeletarUsuarioCommand : IRequest
    {
        public DeletarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
