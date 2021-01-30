using Dell.Academy.Atividade.Application.Models.Validations;

namespace Dell.Academy.Atividade.Application.Models
{
    public class Endereco : EntidadeBase
    {
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public long FuncionarioId { get; private set; }
        public Funcionario Funcionario { get; set; }

        protected Endereco()
        {
        }

        public Endereco(string rua, int numero, string bairro, string cep, string cidade, string estado, long funcionarioId)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cep = CpfValidator.OnlyNumbers(cep);
            Cidade = cidade;
            Estado = estado;
            FuncionarioId = funcionarioId;
        }
    }
}