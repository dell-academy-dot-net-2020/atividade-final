using System.Collections.Generic;
using System.Net;

namespace Dell.Academy.Atividade.Application.ViewModels
{
    public class ErrorViewModel
    {
        public List<string> Errors { get; set; }
        public bool HasErrors => Errors?.Count > 0;
        public HttpStatusCode HttpStatusCode { get; set; }

        public ErrorViewModel() => Errors = new List<string>();

        public ErrorViewModel(List<string> errors, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            Errors = errors;
            HttpStatusCode = httpStatusCode;
        }
    }
}