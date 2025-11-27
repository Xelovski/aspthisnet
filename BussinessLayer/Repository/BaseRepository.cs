using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces.Repository;
using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;

namespace BussinessLayer.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {   
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByPublicIdAsync(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
