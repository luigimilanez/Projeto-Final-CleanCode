using clean_code_refactor.Business.Models.Clientes;
using clean_code_refactor.Domain.Services.Base;
using clean_code_refactor.Domain.ViewModels;

namespace clean_code_refactor.Domain.Services.Clientes
{
    public interface IClienteService : IBaseService<Cliente, ClienteViewModel>
    {
    }
}
