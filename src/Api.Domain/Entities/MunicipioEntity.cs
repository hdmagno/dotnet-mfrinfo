using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;
using Api.Domain.Entity;

namespace Api.Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        [Required]

        public Guid UfId { get; set; }
        public UfEntity Uf { get; set; }

        public ICollection<CepEntity> Ceps { get; set; }
    }
}
