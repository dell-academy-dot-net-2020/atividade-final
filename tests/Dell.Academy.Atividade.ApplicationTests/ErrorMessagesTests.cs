using Bogus;
using Bogus.Extensions.Brazil;
using Dell.Academy.Atividade.Application.Extensions;
using Xunit;

namespace Dell.Academy.Atividade.ApplicationTests
{
    [Collection(nameof(ApplicationTestsCollection))]
    public class ErrorMessagesTests
    {
        private readonly Faker _faker;

        public ErrorMessagesTests(ApplicationTestsFixture fixture) => _faker = fixture.Faker;

        [Fact]
        public void DatabaseCommitError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "Erro ao persistir informações no banco";

            // Act
            var result = ErrorMessages.DatabaseCommitError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CpfSizeError_ShouldReturnCpfSizeErrorMessage()
        {
            // Arrange
            var errorMessage = "O campo Cpf precisa ter 11 caracteres";

            // Act
            var result = ErrorMessages.CpfSizeError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CpfInvalidError_ShouldReturnCpfInvalidErrorMessage()
        {
            // Arrange
            var errorMessage = "O Cpf fornecido não é válido";

            // Act
            var result = ErrorMessages.CpfInvalidError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void FuncionarioIdExistsError_ShouldReturnFuncionarioIdErrorMessage()
        {
            // Arrange
            var funcionarioId = _faker.Random.Int(0);
            var errorMessage = $"O Funcionario com o id {funcionarioId} não foi encontrado";

            // Act
            var result = ErrorMessages.FuncionarioIdExistsError(funcionarioId);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void FuncionarioCpfExistsError_ShouldReturnFuncionarioCpfErrorMessage()
        {
            // Arrange
            var cpf = _faker.Person.Cpf();
            var errorMessage = $"O Funcionario com o cpf {cpf} não foi encontrado";

            // Act
            var result = ErrorMessages.FuncionarioCpfExistsError(cpf);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void EnderecoExistsError_ShouldReturnEnderecoExistsErrorMessage()
        {
            // Arrange
            var enderecoId = _faker.Random.Int(0);
            var errorMessage = $"O Endereço com o id {enderecoId} não foi encontrado";

            // Act
            var result = ErrorMessages.EnderecoExistsError(enderecoId);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void FuncionarioExistsError_ShouldReturnFuncionarioCpfExistsErrorMessage()
        {
            // Arrange
            var cpf = _faker.Person.Cpf();
            var errorMessage = $"O Cpf {cpf} já foi cadastrado";

            // Act
            var result = ErrorMessages.FuncionarioExistsError(cpf);

            // Assert
            Assert.Equal(errorMessage, result);
        }
    }
}