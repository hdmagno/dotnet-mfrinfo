using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Api.Domain.Entity;
using Api.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Dto;

namespace Api.Infra.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<UserEntity> SelectAsync(string email)
        {
            try
            {
                var result = await _dataset.FirstOrDefaultAsync(x => x.Email.Equals(email));

                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
