using Dell.Academy.Atividade.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Application.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<Funcionario>> GetAllAsync();

        Task<Funcionario> GetByCpfAsync(string cpf);

        Task<Funcionario> GetByIdAsync(long id);

        Task<bool> InsertAsync(Funcionario entity);

        Task<bool> UpdateAsync(Funcionario entity);

        Task<bool> DeleteAsync(Funcionario entity);
    }
}