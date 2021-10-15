using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Api.Domain.Entity;
using Api.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Api.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public virtual async Task<T> InsertAsync(T entity)
        {
            try
            {
                entity.CreateAt = DateTime.UtcNow;

                _dataset.Add(entity);
                await _context.SaveChangesAsync();

                entity.CreateAt = entity.CreateAt.AddHours(-3);

                return entity;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual async Task<T> UpdateAsync(T entity, Guid Id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(Id));

                if (result == null)
                {
                    return null;
                }
                else
                {
                    entity.UpdateAt = entity.UpdateAt.AddHours(-3);

                    _context.Entry(result).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();

                    return entity;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id.Equals(id));

                if (result == null)
                {
                    return false;
                }
                else
                {
                    _dataset.Remove(result);
                    await _context.SaveChangesAsync();

                    return true;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);

                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                var result = await _context.Set<T>().ToListAsync();

                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
