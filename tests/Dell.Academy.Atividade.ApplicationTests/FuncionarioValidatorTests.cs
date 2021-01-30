using Bogus;
using Bogus.Extensions.Brazil;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.Models.Enums;
using Dell.Academy.Atividade.Application.Models.Validations;
using System;
using System.Linq;
using Xunit;

namespace Dell.Academy.Atividade.ApplicationTests
{
    [Collection(nameof(ApplicationTestsCollection))]
    public class FuncionarioValidatorTests
    {
        private readonly Faker _faker;
        private readonly FuncionarioValidator _validator;
        private readonly ApplicationTestsFixture _fixture;

        public FuncionarioValidatorTests(ApplicationTestsFixture fixture)
        {
            _faker = fixture.Faker;
            _validator = new FuncionarioValidator();
            _fixture = fixture;
        }

        [Fact]
        public void ReceiveAValidFuncionario_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario("Nome Funcionario", new DateTime(2004, 12, 31), _faker.Person.Cpf(), Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAFuncionarioWithEmptyName_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario(string.Empty, new DateTime(2004, 12, 31), _faker.Person.Cpf(), Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("NomeCompleto", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerFuncionarioName_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario(_faker.Random.String(0, 9), new DateTime(2004, 12, 31), _faker.Person.Cpf(), Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("NomeCompleto", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerFuncionarioName_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario(_faker.Random.String(101, 200), new DateTime(2004, 12, 31), _faker.Person.Cpf(), Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("NomeCompleto", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveADateBiggerThan2005_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario("Nome Completo", new DateTime(2005, 1, 1), _faker.Person.Cpf(), Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("DataNascimento", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveEmptyAddress_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario("Nome Completo", new DateTime(2004, 12, 31), _faker.Person.Cpf(), Sexo.Masculino, null);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Endereco", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveACpfSmallSize_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario("Nome Completo", new DateTime(2004, 12, 31), "156595", Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cpf", result.Errors.FirstOrDefault().PropertyName);
            Assert.Contains("ter 11 caracteres", result.Errors.FirstOrDefault().ErrorMessage);
        }

        [Fact]
        public void ReceiveACpfBigSize_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario("Nome Completo", new DateTime(2004, 12, 31), "123456789101", Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cpf", result.Errors.FirstOrDefault().PropertyName);
            Assert.Contains("ter 11 caracteres", result.Errors.FirstOrDefault().ErrorMessage);
        }

        [Fact]
        public void ReceiveAnInvalidCpf_ShouldValidateProvider()
        {
            // Arrange
            var funcionario = new Funcionario("Nome Completo", new DateTime(2004, 12, 31), "03551325325", Sexo.Masculino, _fixture.ValidEndereco);

            // Act
            var result = _validator.Validate(funcionario);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cpf", result.Errors.FirstOrDefault().PropertyName);
            Assert.Contains("não é válido", result.Errors.FirstOrDefault().ErrorMessage);
        }
    }
}