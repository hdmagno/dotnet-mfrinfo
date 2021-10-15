using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }

    }
}
