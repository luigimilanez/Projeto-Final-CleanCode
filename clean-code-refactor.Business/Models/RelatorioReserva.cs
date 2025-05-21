using clean_code_refactor.Business.Models.Reservas;

namespace clean_code_refactor.Domain.Models
{
    public class RelatorioReserva
    {
        public string Status { get; set; }
        public List<Reserva> Reservas { get; set; }
        public decimal TotalRecebido { get; set; }
    }
}
