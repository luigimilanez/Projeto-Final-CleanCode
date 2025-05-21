namespace clean_code_refactor.Domain.Bases
{
    public class Result
    {
        protected internal Result(bool isSuccess, List<Error> errors)
        {
            if (isSuccess && errors.Any())
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && !errors.Any())
            {
                throw new InvalidOperationException();
            }

            Success = isSuccess;
            Errors = errors;
        }

        public bool Success { get; }

        public List<Error> Errors { get; }

        public static Result SetSuccess() => new(true, new List<Error>());

        public static Result<TValue> SetSuccess<TValue>(TValue value) => new(value, true, new List<Error>());

        public static Result Failure(List<Error> errors) => new(false, errors);

        public static Result<TValue> SetFailure<TValue>(List<Error> errors) => new(default, false, errors);

        public static Result<TValue> Create<TValue>(TValue? value, string field) =>
            value is not null ? SetSuccess(value) : SetFailure<TValue>(new List<Error> { Error.NullValue(field) });
    }
}
