using System;

namespace Confitec.Domain.Entities
{
    public class Usuario
    {

        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public void setEscolaridade(Escolaridade escolaridade)
        {
            Escolaridade = escolaridade;
        }


        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }


        public void Alterar(string nome, string sobrenome, string email, DateTime dataNascimento, Escolaridade escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }
    }

    
}