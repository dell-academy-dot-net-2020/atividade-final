using Dell.Academy.Atividade.Application.Models;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Application.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<bool> UpdateAsync(Endereco entity);
    }
}