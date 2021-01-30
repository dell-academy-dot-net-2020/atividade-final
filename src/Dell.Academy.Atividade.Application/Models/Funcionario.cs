using Dell.Academy.Atividade.Application.Models.Enums;
using Dell.Academy.Atividade.Application.Models.Validations;
using System;

namespace Dell.Academy.Atividade.Application.Models
{
    public class Funcionario : EntidadeBase
    {
        public string NomeCompleto { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public Sexo Sexo { get; private set; }
        public Endereco Endereco { get; private set; }

        protected Funcionario()
        {
        }

        public Funcionario(string nomeCompleto, DateTime dataNascimento, string cpf, Sexo sexo, Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Cpf = CpfValidator.OnlyNumbers(cpf);
            Sexo = sexo;
            Endereco = endereco;
        }
    }
}