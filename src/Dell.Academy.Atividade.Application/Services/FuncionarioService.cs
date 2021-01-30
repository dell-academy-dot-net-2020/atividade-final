using AutoMapper;
using Dell.Academy.Atividade.Application.Extensions;
using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.Models.Validations;
using Dell.Academy.Atividade.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Application.Services
{
    public class FuncionarioService : Service, IFuncionarioService
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        private readonly IMapper _mapper;

        public FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio, IEnderecoRepositorio addressRepository,
            IMapper mapper)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _enderecoRepositorio = addressRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioViewModel> GetFuncionarioByCpfAsync(string cpf)
        {
            var funcionario = await GetFuncionario(cpf);
            return _mapper.Map<FuncionarioViewModel>(funcionario);
        }

        public async Task<FuncionarioViewModel> GetFuncionarioByIdAsync(long id)
        {
            var funcionario = await _funcionarioRepositorio.GetByIdAsync(id);
            return _mapper.Map<FuncionarioViewModel>(funcionario);
        }

        public async Task<List<FuncionarioViewModel>> GetFuncionariosAsync()
        {
            var funcionarios = await _funcionarioRepositorio.GetAllAsync();
            return _mapper.Map<List<FuncionarioViewModel>>(funcionarios);
        }

        public async Task<ErrorViewModel> InsertFuncionarioAsync(FuncionarioViewModel viewModel)
        {
            var funcionario = _mapper.Map<Funcionario>(viewModel);
            if (!EntityIsValid(new FuncionarioValidator(), funcionario)
                || !EntityIsValid(new EnderecoValidator(), funcionario.Endereco))
                return ValidationErrors();

            if (!(await GetFuncionario(viewModel.Cpf) is null))
                return Error(ErrorMessages.FuncionarioExistsError(viewModel.Cpf));

            return Commit(await _funcionarioRepositorio.InsertAsync(funcionario));
        }

        public async Task<ErrorViewModel> UpdateEnderecoAsync(EnderecoViewModel viewModel)
        {
            var endereco = _mapper.Map<Endereco>(viewModel);
            if (!EntityIsValid(new EnderecoValidator(), endereco))
                return ValidationErrors();

            if (await _enderecoRepositorio.GetByIdAsync(viewModel.Id) is null)
                return Error(ErrorMessages.EnderecoExistsError(viewModel.Id));

            return Commit(await _enderecoRepositorio.UpdateAsync(endereco));
        }

        public async Task<ErrorViewModel> UpdateFuncionarioAsync(FuncionarioViewModel viewModel)
        {
            var funcionario = _mapper.Map<Funcionario>(viewModel);
            if (!EntityIsValid(new FuncionarioValidator(), funcionario)
                || !EntityIsValid(new EnderecoValidator(), funcionario.Endereco))
                return ValidationErrors();

            if (await _funcionarioRepositorio.GetByIdAsync(viewModel.Id) is null)
                return Error(ErrorMessages.FuncionarioIdExistsError(viewModel.Id));

            if (!(await GetFuncionario(viewModel.Cpf) is null))
                return Error(ErrorMessages.FuncionarioExistsError(viewModel.Cpf));

            return Commit(await _funcionarioRepositorio.UpdateAsync(funcionario));
        }

        public async Task<ErrorViewModel> DeleteFuncionarioAsync(long id)
        {
            var funcionario = await _funcionarioRepositorio.GetByIdAsync(id);
            if (funcionario is null)
                return Error(ErrorMessages.FuncionarioIdExistsError(id));

            return Commit(await _funcionarioRepositorio.DeleteAsync(funcionario));
        }

        private async Task<Funcionario> GetFuncionario(string cpf)
            => await _funcionarioRepositorio.GetByCpfAsync(CpfValidator.OnlyNumbers(cpf));
    }
}