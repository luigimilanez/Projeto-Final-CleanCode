using AutoMapper;
using clean_code_refactor.Business.Models.Reservas;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Services.Base;
using clean_code_refactor.Domain.ViewModels;

namespace clean_code_refactor.Domain.Services.Reservas
{
    public class ReservaService : BaseService<Reserva, ReservaViewModel>, IReservaService
    {
        public ReservaService(IBaseRepository<Reserva> reservaRep, IMapper mapper, IValidation<ReservaViewModel> validation) 
            : base(reservaRep, mapper, validation) {}

        public async Task RealizarCheckIn(int id)
        {
            var result = await Recuperar(id);

            result.Value.RealizarCheckIn();

            await Rep.AtualizarAsync(result.Value);
        }

        public async Task RealizarCheckOut(int id)
        {
            var result = await Recuperar(id);

            result.Value.RealizarCheckOut();

            await Rep.AtualizarAsync(result.Value);
        }

        public async Task Cancelar(int id)
        {
            var result = await Recuperar(id);

            result.Value.RealizarCancelamento();

            await Rep.AtualizarAsync(result.Value);
        }
    }
}
