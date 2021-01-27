using Dell.Academy.Atividade.Application.Models.Enums;

namespace Dell.Academy.Atividade.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public Sexo Sexo { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}