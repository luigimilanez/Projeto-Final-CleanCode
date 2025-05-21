using AutoMapper;
using clean_code_refactor.Domain.Bases;

namespace clean_code_refactor.Domain.Services.Base
{
    //Esta classe não pode ser abstrata, para que o AddScoped funcione
    public class BaseService<T, TViewModel> : IBaseService<T, TViewModel>
        where T : Identificador
        where TViewModel : class
    {
        protected IMapper Mapper;
        protected IBaseRepository<T> Rep;
        protected IValidation<TViewModel> Validation;
        public BaseService(IBaseRepository<T> rep, IMapper mapper, IValidation<TViewModel> validation)
        {
            Rep = rep;
            Mapper = mapper;
            Validation = validation;
        }

        public async Task<Result<IList<T>>> Recuperar() => Result.SetSuccess(await Rep.ObterTodosAsync());

        public async Task<Result<T>> Recuperar(int id)
        {
            var entity = await Rep.ObterPorIdAsync(id) 
                ?? throw new Exception($"Não foi possível encontrar {typeof(T).Name} com código {id}");

            return Result.SetSuccess(entity);
        }

        public virtual async Task<Result<T>> Inserir(TViewModel viewModel)
        {
            var errors = Validation.CreatingValidation(viewModel);

            if (errors.Count != 0)
                return Result.SetFailure<T>(errors);

            var entity = Mapper.Map<T>(viewModel);

            return await Rep.AdicionarAsync(entity);
        }
    }
}
