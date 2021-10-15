using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entity;

namespace Api.Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }
        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }
        [Required]
        [MaxLength(10)]
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioEntity Municipio { get; set; }
    }
}
