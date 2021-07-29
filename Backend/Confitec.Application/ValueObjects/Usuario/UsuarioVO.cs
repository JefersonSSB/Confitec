using System;
using Confitec.Application.ValueObjects.Escolaridade;

namespace Confitec.Application.ValueObjects.Usuario
{
    public class UsuarioVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Escolaridade { get; set; }
        public int? EscolaridadeId { get; set; }

    }
}