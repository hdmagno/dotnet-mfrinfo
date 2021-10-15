using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
