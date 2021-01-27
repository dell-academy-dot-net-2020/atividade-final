using Dell.Academy.Atividade.Application.Extensions;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Dell.Academy.Atividade.Application.Services
{
    public abstract class Service
    {
        private static ValidationResult _validationResult;

        protected static ErrorViewModel ValidationErrors()
            => new ErrorViewModel(_validationResult.Errors.Select(e => e.ErrorMessage).ToList());

        protected ErrorViewModel Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var errors = new List<string> { errorMessage };
            return new ErrorViewModel(errors, statusCode);
        }

        protected ErrorViewModel Commit(bool result)
        {
            if (!result)
                return Error(ErrorMessages.DatabaseCommitError);

            return new ErrorViewModel();
        }

        protected static bool EntityIsValid<TV, TE>(TV validator, TE entity) where TV : AbstractValidator<TE> where TE : EntidadeBase
        {
            var result = validator.Validate(entity);
            if (result.IsValid) return true;

            _validationResult = result;
            return false;
        }
    }
}