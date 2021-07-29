using System;
using Confitec.Application.ValueObjects.Usuario;
using MediatR;


namespace Confitec.Application.Queries
{
    public class BuscarUsuarioPorIdQuery : IRequest<UsuarioVO>
    {
        public BuscarUsuarioPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}


