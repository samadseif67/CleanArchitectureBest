using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.IPersistence;
using OnlineShop.Persistence.Context;
using OnlineShop.Persistence.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence
{
    public static class PersistenceServiceRegisteration
    {
        public static IServiceCollection PersistenceConfig(this IServiceCollection services, IConfiguration configure)
        {
            services.AddDbContext<OnlineShopDbContext>(options => { options.UseSqlServer(configure.GetConnectionString("OnlineShop")); });
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            return services;
        }
    }
}
