namespace clean_code_refactor.Domain.Bases
{
    public abstract class Validation<TViewModel> : IValidation<TViewModel> where TViewModel : class
    {
        public abstract List<Error> CreatingValidation(TViewModel dto);
    }
}
