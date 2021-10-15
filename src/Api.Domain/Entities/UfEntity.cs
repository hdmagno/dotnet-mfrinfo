using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entity;

namespace Api.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public ICollection<MunicipioEntity> Municipios { get; set; }
    }
}
