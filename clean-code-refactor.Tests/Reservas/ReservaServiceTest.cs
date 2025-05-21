using AutoMapper;
using clean_code_refactor.Business.Models.Reservas;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Models;
using clean_code_refactor.Domain.Models.Reservas;
using clean_code_refactor.Domain.Services.Reservas;
using clean_code_refactor.Domain.ViewModels;
using Moq;

public class ReservaServiceTests
{
    private readonly Mock<IBaseRepository<Reserva>> _reservaRepoMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IValidation<ReservaViewModel>> _validationMock;
    private readonly ReservaService _reservaService;

    public ReservaServiceTests()
    {
        _reservaRepoMock = new Mock<IBaseRepository<Reserva>>();
        _mapperMock = new Mock<IMapper>();
        _validationMock = new Mock<IValidation<ReservaViewModel>>();
        _reservaService = new ReservaService(_reservaRepoMock.Object, _mapperMock.Object, _validationMock.Object);
    }

    [Fact]
    public async Task RealizarCheckIn_DeveAtualizarReservaComStatusAtivo()
    {
        // Arrange
        var reserva = new Reserva(2, TipoQuartoEnum.Deluxe, 3, 1);
        var reservaId = 10;
        _reservaRepoMock
            .Setup(r => r.ObterPorIdAsync(reservaId))
            .ReturnsAsync(reserva);

        // Act
        await _reservaService.RealizarCheckIn(reservaId);

        // Assert
        Assert.Equal(StatusReservaEnum.Ativo, reserva.Status);
        _reservaRepoMock.Verify(r => r.AtualizarAsync(reserva), Times.Once);
    }

    [Fact]
    public async Task RealizarCheckOut_DeveAtualizarReservaComStatusFinalizado()
    {
        // Arrange
        var reserva = new Reserva(2, TipoQuartoEnum.Premium, 2, 1);
        var reservaId = 20;
        _reservaRepoMock
            .Setup(r => r.ObterPorIdAsync(reservaId))
            .ReturnsAsync(reserva);

        // Act
        await _reservaService.RealizarCheckOut(reservaId);

        // Assert
        Assert.Equal(StatusReservaEnum.Finalizado, reserva.Status);
        _reservaRepoMock.Verify(r => r.AtualizarAsync(reserva), Times.Once);
    }

    [Fact]
    public async Task Cancelar_DeveAtualizarReservaComStatusCancelado()
    {
        // Arrange
        var reserva = new Reserva(1, TipoQuartoEnum.Premium, 5, 1);
        var reservaId = 30;
        _reservaRepoMock
            .Setup(r => r.ObterPorIdAsync(reservaId))
            .ReturnsAsync(reserva);

        // Act
        await _reservaService.Cancelar(reservaId);

        // Assert
        Assert.Equal(StatusReservaEnum.Cancelado, reserva.Status);
        _reservaRepoMock.Verify(r => r.AtualizarAsync(reserva), Times.Once);
    }
}
