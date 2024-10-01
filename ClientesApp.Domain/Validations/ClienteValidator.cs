using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;
        
        public ClienteValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("O id do cliente é obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .MaximumLength(150).WithMessage("O nome do cliente deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O e-mail do cliente deve ter no máximo 100 caracteres.")
                .EmailAddress().WithMessage("O e-mail do cliente é inválido.")
                .MustAsync(BeUniqueEmail).WithMessage("O Email do cliente já está em uso."); ;


            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF do cliente é obrigatório.")
                .MaximumLength(11).WithMessage("O CPF do cliente deve ter no máximo 11 caracteres.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("O CPF do cliente é inválido.")
                .MustAsync(BeUniqueCpf).WithMessage("O CPF do cliente já está em uso.");

        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _clienteRepository.VerifyExistsAsync(c => c.Email.Equals(email));
        }

        private async Task<bool> BeUniqueCpf(string cpf, CancellationToken cancellationToken)
        {
            return await _clienteRepository.VerifyExistsAsync(c => c.Cpf.Equals(cpf));
        }
    }

}
