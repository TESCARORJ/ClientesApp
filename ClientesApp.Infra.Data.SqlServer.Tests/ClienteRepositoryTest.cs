using Bogus;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Infra.Data.SqlServer.Contexts;
using ClientesApp.Infra.Data.SqlServer.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ClientesApp.Infra.Data.SqlServer.Tests
{
    public class ClienteRepositoryTest
    {
        private readonly Faker<Cliente> _fakerCliente;
        //private readonly Mock<DataContext> _mockContext;
        private readonly DataContext _dataContext;
        private readonly ClienteRepository _clienteRepository;

        public ClienteRepositoryTest()
        {
            //Configurar o Bogus para consttruir um cliente
            _fakerCliente = new Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Cpf, f => f.Random.Replace("###########"));

            //configurar o DataContext para utilizar banco de memória no EF
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ClienteAppTestDB")
                .Options;

            //criando o mock da classe DataContext
            //_dataContext = new Mock<DataContext>(options);
            _dataContext = new DataContext(options);

            //instanciando a classe de repositório
            //_clienteRepository = new ClienteRepository(_mockContext.Object);
            _clienteRepository = new ClienteRepository(_dataContext);
        }

        //[Fact(Skip = "Não Implementado", DisplayName = "Adicionar cliente com sucesso no repositório")]
        [Fact(DisplayName = "Adicionar cliente com sucesso no repositório")]
        public async Task AddAsync_ShouldAddCliente()
        {
            //gerando os dados do cliente
            var cliente = _fakerCliente.Generate();

            //gravando o cliente no banco de dados
            await _clienteRepository.AddAsync(cliente);

            //buscando p cliente no banco de dados através do ID
            var clienteCadastrado = await _clienteRepository.GetByIdAsync(cliente.Id);

            //verificar se o cliente foi cadastrado (asserções de teste)
            clienteCadastrado.Should().NotBeNull();
            clienteCadastrado?.Nome.Should().BeSameAs(cliente.Nome);
            clienteCadastrado?.Email.Should().BeSameAs(cliente.Email);
            clienteCadastrado?.Cpf.Should().BeSameAs(cliente.Cpf);

        }
    }
}
