namespace clean_code_refactor.Domain.Bases
{
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, List<Error> errors)
            : base(isSuccess, errors)
        {
            _value = value;
        }

        public TValue? Value => Success
        ? _value!
        : default;

        public static implicit operator Result<TValue>(TValue? value) => Create(value, "");
    }
}
