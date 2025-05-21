using clean_code_refactor.Business.Models.Clientes;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Services.Reservas.Validations.Errors;
using clean_code_refactor.Domain.ViewModels;

namespace clean_code_refactor.Domain.Services.Reservas.Validations
{
    public class ReservaValidation : Validation<ReservaViewModel>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;
        public ReservaValidation(IBaseRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public override List<Error> CreatingValidation(ReservaViewModel dto)
        {
            var errors = new List<Error>();

            if (dto.QuantidadePessoas < 1 || dto.QuantidadePessoas > 4)
                errors.Add(ReservaErrors.QuantidadePessoasError());

            if (dto.Diarias < 1)
                errors.Add(ReservaErrors.DiariasError());
            
            if (_clienteRepository.ObterPorId(dto.ClienteId) == null)
                errors.Add(ReservaErrors.ClienteNaoEncontradoError());

            if (dto.DataReserva < DateTime.Today)
                errors.Add(ReservaErrors.DataReservaIncorreta());

            return errors;
        }
    }
}
