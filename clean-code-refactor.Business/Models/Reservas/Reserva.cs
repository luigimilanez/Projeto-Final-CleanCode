using AutoMapper;
using clean_code_refactor.Business.Models.Clientes;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Models;
using clean_code_refactor.Domain.Models.Reservas;
using clean_code_refactor.Domain.ViewModels;
using System.Text.Json.Serialization;

namespace clean_code_refactor.Business.Models.Reservas
{
    public class Reserva : Identificador
    {
        public Reserva(
            int quantidadePessoas,
            TipoQuartoEnum tipoQuarto,
            int diarias,
            int clienteId)
        {
            ClienteId = clienteId;
            QuantidadePessoas = quantidadePessoas;
            TipoQuarto = tipoQuarto;
            Diarias = diarias;
            ValorTotal = quantidadePessoas * diarias * (int)tipoQuarto;
            Status = StatusReservaEnum.Reservado;
        }

        public StatusReservaEnum Status { get; private set; }
        public int QuantidadePessoas { get; private set; }
        public int Diarias { get; private set; }
        public TipoQuartoEnum TipoQuarto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataReserva { get; private set; } = DateTime.Now;
        public DateTime DataCheckIn { get; private set; }
        public DateTime DataCheckOut { get; private set; }
        public int ClienteId { get; private set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }

        public void RealizarCheckIn()
        {
            DataCheckIn = DateTime.Now;
            Status = StatusReservaEnum.Ativo;
        }

        public void RealizarCheckOut()
        {
            DataCheckOut = DateTime.Now;
            Status = StatusReservaEnum.Finalizado;
        }

        public void RealizarCancelamento()
        {
            Status = StatusReservaEnum.Cancelado;
        }
    }

    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<ReservaViewModel, Reserva>();
            CreateMap<Reserva, ReservaViewModel>();
        }
    }
}
