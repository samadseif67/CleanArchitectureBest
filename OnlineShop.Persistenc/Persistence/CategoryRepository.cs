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
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        private readonly OnlineShopDbContext _dbContext;
        public CategoryRepository(OnlineShopDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }




    }
}
