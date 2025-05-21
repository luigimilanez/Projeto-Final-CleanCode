namespace clean_code_refactor.Domain.Bases
{
    public interface IValidation<TViewModel> where TViewModel : class
    {
        List<Error> CreatingValidation(TViewModel dto);
    }
}
