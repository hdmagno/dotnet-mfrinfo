using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }
    }
}
