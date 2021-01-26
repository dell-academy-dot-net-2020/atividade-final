using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Data.Repositories
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly ApiContexto _context;

        public FuncionarioRepositorio(ApiContexto context) => _context = context;

        public async Task<List<Funcionario>> GetAllAsync() => await _context.Funcionarios.AsNoTracking().ToListAsync();

        public async Task<Funcionario> GetByIdAsync(long id)
            => await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<bool> InsertAsync(Funcionario entity)
        {
            _context.Funcionarios.Add(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Funcionario entity)
        {
            _context.Funcionarios.Update(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _context.Funcionarios.Remove(new Funcionario() { Id = id });
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}