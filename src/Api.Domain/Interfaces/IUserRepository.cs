using System.Threading.Tasks;
using Api.Domain.Entity;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> SelectAsync(string email);
    }
}
