using AutoMapper;
using Bogus;
using Bogus.Extensions.Brazil;
using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.Models.Enums;
using Dell.Academy.Atividade.Application.Models.Validations;
using Moq;
using Moq.AutoMock;
using System;

namespace Dell.Academy.Atividade.ApplicationTests
{
    public class ApplicationTestsFixture
    {
        public Faker Faker => new Faker("pt_BR");
        public readonly AutoMocker AutoMocker;
        public readonly string ValidCpf;

        public ApplicationTestsFixture()
        {
            AutoMocker = new AutoMocker();
            ValidCpf = CpfValidator.OnlyNumbers(Faker.Person.Cpf());
        }

        public Funcionario ValidFuncionario => new Funcionario("Nome Funcionario", new DateTime(2004, 12, 31), ValidCpf, Sexo.Masculino, new Endereco());

        public Mock<IFuncionarioRepositorio> GetFuncionarioRepositorio()
            => AutoMocker.GetMock<IFuncionarioRepositorio>();

        public Mock<IMapper> GetAutoMapper()
            => AutoMocker.GetMock<IMapper>();
    }
}