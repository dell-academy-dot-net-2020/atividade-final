using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Data.Repositories
{
    public abstract class Repositorio
    {
        protected readonly ApiContexto Context;

        protected Repositorio(ApiContexto context) => Context = context;

        protected async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : EntidadeBase
            => await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        protected async Task<bool> UpdateAsync<TEntity>(EntidadeBase entity) where TEntity : EntidadeBase
        {
            Context.Set<TEntity>().Update(entity as TEntity);
            return await SaveChangesAsync();
        }

        protected async Task<bool> SaveChangesAsync() => await Context.SaveChangesAsync() > 0;
    }
}