using Dell.Academy.Atividade.Application.Extensions;
using FluentValidation;
using System;

namespace Dell.Academy.Atividade.Application.Models.Validations
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(p => p.NomeCompleto).NotEmpty().Length(10, 100);
            RuleFor(p => p.DataNascimento).NotEmpty().LessThan(new DateTime(2005, 1, 1));
            RuleFor(p => p.Endereco).NotEmpty();
            RuleFor(p => p.Cpf.Length == CpfValidator.CpfSize).Equal(true).OverridePropertyName("Cpf").WithMessage(ErrorMessages.CpfSizeError);
            RuleFor(p => CpfValidator.Validate(p.Cpf)).Equal(true).OverridePropertyName("Cpf").WithMessage(ErrorMessages.CpfInvalidError);
        }
    }
}