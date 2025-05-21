using clean_code_refactor.Domain.Bases;

namespace clean_code_refactor.Domain.Services.Reservas.Validations.Errors
{
    public class ReservaErrors
    {
        public static Error QuantidadePessoasError() => new("Error.InvalidPeople", $"A Quantidade de pessoas deve ser entre 1 e 4.");
        public static Error DiariasError() => new("Error.InvalidDiarias", $"Número de diárias inválido: deve ser maior que zero.");
        public static Error TipoQuartoError(string field) => new("Error.InvalidTipoQuarto", $"O {field} deve ser 1, 2 ou 3.");
        public static Error ClienteNaoEncontradoError() => new("Error.NotFound", "Cliente não encontrado");
        public static Error DataReservaIncorreta() => new("Error.InvalidDate", "Data da reserva inferior ao dia de hoje");
    }
}
