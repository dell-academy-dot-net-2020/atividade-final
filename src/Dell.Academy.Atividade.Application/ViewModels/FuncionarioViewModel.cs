using Dell.Academy.Atividade.Application.Models.Enums;
using System;

namespace Dell.Academy.Atividade.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public short Sexo { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}