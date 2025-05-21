using AutoMapper;
using clean_code_refactor.Business.Models.Clientes;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Services.Clientes;
using clean_code_refactor.Domain.Services.Clientes.Validations.Errors;
using clean_code_refactor.Domain.ViewModels;
using Moq;

public class ClienteServiceTests
{
    private readonly Mock<IBaseRepository<Cliente>> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IValidation<ClienteViewModel>> _validationMock;
    private readonly ClienteService _clienteService;

    public ClienteServiceTests()
    {
        _repositoryMock = new Mock<IBaseRepository<Cliente>>();
        _mapperMock = new Mock<IMapper>();
        _validationMock = new Mock<IValidation<ClienteViewModel>>();
        _clienteService = new ClienteService(_repositoryMock.Object, _mapperMock.Object, _validationMock.Object);
    }

    [Fact]
    public async Task Inserir_DeveRetornarErro_SeValidacaoFalhar()
    {
        // Arrange
        var viewModel = new ClienteViewModel { Nome = "", Cpf = "123" };
        var expectedErrors = new List<Error> { ClienteErrors.CpfError("Cpf") };

        _validationMock
            .Setup(v => v.CreatingValidation(viewModel))
            .Returns(expectedErrors);

        // Act
        var result = await _clienteService.Inserir(viewModel);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(expectedErrors, result.Errors);
    }

    [Fact]
    public async Task Inserir_DeveRetornarSucesso_SeValidacaoPassar()
    {
        // Arrange
        var viewModel = new ClienteViewModel { Nome = "João", Cpf = "12345678901" };
        var cliente = new Cliente { Id = 1, Nome = "João", Cpf = "12345678901" };

        _validationMock
            .Setup(v => v.CreatingValidation(viewModel))
            .Returns(new List<Error>());

        _mapperMock
            .Setup(m => m.Map<Cliente>(viewModel))
            .Returns(cliente);

        _repositoryMock
            .Setup(r => r.AdicionarAsync(cliente))
            .ReturnsAsync(cliente); // <- Corrigido aqui

        // Act
        var result = await _clienteService.Inserir(viewModel);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(cliente, result.Value);
    }

}
