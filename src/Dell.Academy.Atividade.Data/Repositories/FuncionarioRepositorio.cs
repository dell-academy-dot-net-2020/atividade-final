using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Data.Repositories
{
    public class FuncionarioRepositorio : Repositorio, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(ApiContexto context) : base(context)
        {
        }

        public async Task<Funcionario> GetByCpfAsync(string cpf)
            => await Context.Funcionarios.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Cpf == cpf);

        public async Task<List<Funcionario>> GetAllAsync()
            => await Context.Funcionarios.AsNoTracking().Include(f => f.Endereco).OrderBy(f => f.NomeCompleto).ToListAsync();

        public async Task<Funcionario> GetByIdAsync(long id) => await GetByIdAsync<Funcionario>(id);

        public async Task<bool> InsertAsync(Funcionario entity)
        {
            Context.Funcionarios.Add(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Funcionario entity) => await UpdateAsync<Funcionario>(entity);

        public async Task<bool> DeleteAsync(Funcionario funcionario)
        {
            Context.Funcionarios.Remove(funcionario);
            return await SaveChangesAsync();
        }
    }
}