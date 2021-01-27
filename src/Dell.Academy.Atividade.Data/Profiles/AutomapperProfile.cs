using AutoMapper;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.ViewModels;

namespace Dell.Academy.Atividade.Data.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
        }
    }
}