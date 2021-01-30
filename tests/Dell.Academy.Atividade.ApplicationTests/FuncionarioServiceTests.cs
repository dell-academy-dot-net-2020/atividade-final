using Bogus;
using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models.Validations;
using Dell.Academy.Atividade.Application.Services;
using Dell.Academy.Atividade.Application.ViewModels;
using Moq;
using Xunit;

namespace Dell.Academy.Atividade.ApplicationTests
{
    [Collection(nameof(ApplicationTestsCollection))]
    public class FuncionarioServiceTests
    {
        private readonly Faker _faker;
        private readonly IFuncionarioService _service;
        private readonly Mock<IFuncionarioRepositorio> _funcionarioRepositorio;
        private readonly ApplicationTestsFixture _fixture;

        public FuncionarioServiceTests(ApplicationTestsFixture fixture)
        {
            _fixture = fixture;
            _faker = fixture.Faker;
            _service = fixture.AutoMocker.CreateInstance<FuncionarioService>();
            _funcionarioRepositorio = fixture.GetFuncionarioRepositorio();
        }

        [Fact]
        public async void GetFuncionarioByCpfAsync_ShouldReturnAFuncionarioByCpf()
        {
            // Arrange
            var cpf = _fixture.ValidCpf;
            var funcionario = _fixture.ValidFuncionario;
            _funcionarioRepositorio.Setup(r => r.GetByCpfAsync(cpf))
                .ReturnsAsync(funcionario);
            _fixture.GetAutoMapper().Setup(m => m.Map<FuncionarioViewModel>(funcionario))
                .Returns(new FuncionarioViewModel { Cpf = funcionario.Cpf, DataNascimento = funcionario.DataNascimento });

            // Act
            var result = await _service.GetFuncionarioByCpfAsync(cpf);

            // Assert
            Assert.IsType<FuncionarioViewModel>(result);
            Assert.Equal(funcionario.Cpf, result.Cpf);
            Assert.Equal(funcionario.DataNascimento, result.DataNascimento);
        }

        [Fact]
        public async void GetFuncionarioByIdAsync_ShouldReturnAFuncionarioById()
        {
            // Arrange
            var funcionarioId = 1;
            var funcionario = _fixture.ValidFuncionario;
            _funcionarioRepositorio.Setup(r => r.GetByIdAsync(funcionarioId))
                .ReturnsAsync(funcionario);
            _fixture.GetAutoMapper().Setup(m => m.Map<FuncionarioViewModel>(funcionario))
                .Returns(new FuncionarioViewModel { Cpf = funcionario.Cpf, DataNascimento = funcionario.DataNascimento });

            // Act
            var result = await _service.GetFuncionarioByIdAsync(funcionarioId);

            // Assert
            Assert.IsType<FuncionarioViewModel>(result);
            Assert.Equal(funcionario.Cpf, result.Cpf);
            Assert.Equal(funcionario.DataNascimento, result.DataNascimento);
        }
    }
}