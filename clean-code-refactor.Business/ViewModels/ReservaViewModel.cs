using clean_code_refactor.Domain.Models;

namespace clean_code_refactor.Domain.ViewModels
{
    public class ReservaViewModel
    {
        public int ClienteId { get; set; }
        public int QuantidadePessoas { get; set; }
        public int Diarias { get; set; }
        public DateTime DataReserva { get; set; }
        public TipoQuartoEnum TipoQuarto { get; set; }
    }
}
