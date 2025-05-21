using clean_code_refactor.Business.Models.Reservas;
using clean_code_refactor.Domain.Services.Base;
using clean_code_refactor.Domain.ViewModels;

namespace clean_code_refactor.Domain.Services.Reservas
{
    public interface IReservaService : IBaseService<Reserva, ReservaViewModel>
    {
        Task Cancelar(int id);
        Task RealizarCheckIn(int id);
        Task RealizarCheckOut(int id);
    }
}
