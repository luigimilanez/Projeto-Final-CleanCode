using clean_code_refactor.Domain.Bases;

namespace clean_code_refactor.Domain.Services.Clientes.Validations.Errors
{
    public class ClienteErrors
    {
        public static Error NullValueError(string field) => new("Error.NullValue", $"O {field} não pode ser nulo!");
        public static Error CpfError(string field) => new("Error.InvalidCpf", $"O {field} deve conter 11 dígitos");
    }
}
