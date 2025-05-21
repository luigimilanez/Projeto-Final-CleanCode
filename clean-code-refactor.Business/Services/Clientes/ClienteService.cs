using AutoMapper;
using clean_code_refactor.Business.Models.Clientes;
using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Services.Base;
using clean_code_refactor.Domain.ViewModels;

namespace clean_code_refactor.Domain.Services.Clientes
{
    public class ClienteService : BaseService<Cliente, ClienteViewModel>, IClienteService
    {
        public ClienteService(
            IBaseRepository<Cliente> clienteRep, 
            IMapper mapper, 
            IValidation<ClienteViewModel> validation) 
            : base(clienteRep, mapper, validation) {}
    }
}
