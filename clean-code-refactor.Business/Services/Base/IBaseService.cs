using clean_code_refactor.Domain.Bases;

namespace clean_code_refactor.Domain.Services.Base
{
    public interface IBaseService<T, TViewModel> where T : Identificador
    {
        Task<Result<T>> Inserir(TViewModel viewModel);
        Task<Result<IList<T>>> Recuperar();
        Task<Result<T>> Recuperar(int id);
    }
}
