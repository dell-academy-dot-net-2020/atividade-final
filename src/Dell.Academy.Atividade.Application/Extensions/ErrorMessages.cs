namespace Dell.Academy.Atividade.Application.Extensions
{
    public static class ErrorMessages
    {
        public static string CpfSizeError => "O campo Cpf precisa ter 11 caracteres";
        public static string CpfInvalidError => "O Cpf fornecido não é válido";
        public static string DatabaseCommitError => "Erro ao persistir informações no banco";

        public static string FuncionarioExistsError(string cpf) => $"O Cpf {cpf} já foi cadastrado";
    }
}