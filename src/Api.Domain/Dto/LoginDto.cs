using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um {0} válido")]
        [StringLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
