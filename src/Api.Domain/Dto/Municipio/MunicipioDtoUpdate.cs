using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto.Municipio
{
    public class MunicipioDtoUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "{0} do município é obrigatório")]
        [StringLength(60, ErrorMessage = "{0} do município deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido")]
        public int CodIbge { get; set; }
        [Required(ErrorMessage = "Código de UF é obrigatório")]
        public Guid UfId { get; set; }
    }
}
