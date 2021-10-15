using System;

namespace Api.Domain.Dto
{
    public class CreateUserDtoResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
