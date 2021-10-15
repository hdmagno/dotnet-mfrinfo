using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entity
{
    public class BaseEntity
    {

        [Key]
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value == Guid.Empty ? Guid.NewGuid() : value;
        }
        private DateTime _createAt;
        public DateTime CreateAt
        {
            get => _createAt;
            set => _createAt = value == new DateTime() ? DateTime.UtcNow : value;
        }

        public DateTime UpdateAt { get; set; }
    }

}
