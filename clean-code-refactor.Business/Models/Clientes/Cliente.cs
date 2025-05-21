using AutoMapper;
using clean_code_refactor.Business.Models.Reservas;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.ViewModels;
using System.Text.Json.Serialization;

namespace clean_code_refactor.Business.Models.Clientes
{
    public class Cliente : Identificador
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }

        [JsonIgnore]
        public ICollection<Reserva> Reservas { get; set; }

    }
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
