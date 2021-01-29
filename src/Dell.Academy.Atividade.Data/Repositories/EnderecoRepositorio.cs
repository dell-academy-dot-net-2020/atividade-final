using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Data.Contexto;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Data.Repositories
{
    public class EnderecoRepositorio : Repositorio, IEnderecoRepositorio
    {
        public EnderecoRepositorio(ApiContexto context) : base(context)
        {
        }

        public async Task<Endereco> GetByIdAsync(long id) => await GetByIdAsync<Endereco>(id);

        public async Task<bool> UpdateAsync(Endereco entity) => await UpdateAsync<Endereco>(entity);
    }
}