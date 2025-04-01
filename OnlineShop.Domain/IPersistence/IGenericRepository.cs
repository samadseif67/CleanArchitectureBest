using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IPersistence
{
    public interface IGenericRepository<TEntity> where TEntity:class, IBaseEntity
    {

        Task<TEntity> Get(Guid ID);
        IQueryable<TEntity> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(Guid ID);
        

    }
}
