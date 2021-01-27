using FluentValidation;

namespace Dell.Academy.Atividade.Application.Models.Validations
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(a => a.Rua).NotEmpty().Length(3, 100);

            RuleFor(a => a.Numero).GreaterThan(0);

            RuleFor(a => a.Cep).NotEmpty().Length(8);

            RuleFor(a => a.Bairro).NotEmpty().Length(3, 100);

            RuleFor(a => a.Cidade).NotEmpty().Length(3, 100);

            RuleFor(a => a.Estado).NotEmpty().Length(2);
        }
    }
}