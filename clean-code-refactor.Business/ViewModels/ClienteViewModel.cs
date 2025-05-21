using System.ComponentModel.DataAnnotations;

namespace clean_code_refactor.Domain.ViewModels
{
    public class ClienteViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
