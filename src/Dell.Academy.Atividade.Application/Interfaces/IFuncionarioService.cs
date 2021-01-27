using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<List<FuncionarioViewModel>> GetFuncionariosAsync();

        Task<FuncionarioViewModel> GetFuncionarioByIdAsync(long id);

        Task<FuncionarioViewModel> GetFuncionarioByCpfAsync(string cpf);

        Task<ErrorViewModel> InsertFuncionarioAsync(FuncionarioViewModel viewModel);

        Task<ErrorViewModel> UpdateFuncionarioAsync(FuncionarioViewModel viewModel);

        Task<ErrorViewModel> UpdateEnderecoAsync(EnderecoViewModel viewModel);

        Task<ErrorViewModel> DeleteFuncionarioAsync(long id);
    }
}