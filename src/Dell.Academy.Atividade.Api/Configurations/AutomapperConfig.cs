using AutoMapper;
using Dell.Academy.Atividade.Data.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dell.Academy.Atividade.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
            => services.AddAutoMapper(Assembly.GetAssembly(typeof(AutomapperProfile)));
    }
}