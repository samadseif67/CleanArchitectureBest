using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IPersistence;
using OnlineShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Persistence
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly OnlineShopDbContext _dbContext;
        private readonly DbSet<TEntity> entities;
        public GenericRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {

            if(entity.ID==Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                entity.CreateDateTime = DateTime.Now;
                entity.IsDelete = false;

                await entities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
             
            return entity;
        }

        public async Task<TEntity> Get(Guid ID)
        {
            var result= await entities.AsNoTracking().FirstOrDefaultAsync(x=>x.ID==ID);
            return result;
        }

        public IQueryable<TEntity> GetAll()
        {
            return entities.AsQueryable().AsNoTracking();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            TEntity Find=await Get(entity.ID);
            
            entity.CreateDateTime = Find.CreateDateTime;
            entity.IsDelete = Find.IsDelete;
             
            entities.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }


        public async Task<bool> Delete(Guid ID)
        {
            var Result = await entities.FindAsync(ID);
            if (Result != null)
            {
                Result.IsDelete = false;
                _dbContext.SaveChanges();
            }
            return true;
        }









    }
}
