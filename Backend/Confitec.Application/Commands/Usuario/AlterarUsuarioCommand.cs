using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Application.Commands.Usuario
{
    public class AlterarUsuarioCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public int EscolaridadeId { get; set; }

    }

}

