using AutoMapper;
using Dell.Academy.Atividade.Application.Extensions;
using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.Models;
using Dell.Academy.Atividade.Application.Models.Validations;
using Dell.Academy.Atividade.Application.ViewModels;
using System;
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

        public Task<ErrorViewModel> UpdateEnderecoAsync(EnderecoViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorViewModel> UpdateFuncionarioAsync(FuncionarioViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorViewModel> DeleteFuncionarioAsync(long id)
        {
            throw new NotImplementedException();
        }

        private async Task<Funcionario> GetFuncionario(string cpf)
            => await _funcionarioRepositorio.GetByCpfAsync(CpfValidator.OnlyNumbers(cpf));
    }
}