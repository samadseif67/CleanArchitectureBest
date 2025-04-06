using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Api.Controllers;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IPersistence;
using OnlineShop.Persistence.Context;
using OnlineShop.Persistence.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace OnlineShop.Api_IntegrationTest.ClassFixture
{
    public class DependenceProjectFixtureIntegration : IDisposable
    {
        public OnlineShopDbContext _dbContext;
        public IMediator _mediator { get; set; }
        public CategoryController _categoryController { get; set; }
        public ICategoryRepository _categoryRepository;


        public DependenceProjectFixtureIntegration(params Assembly[] handlerAssembly)
        {

            string OnlineShopTestConnection = "Server=DESKTOP-6OT3NPD\\SQL2022;Database=OnlineShop1404Test;User Id=sa;password=123456;Trusted_Connection=False;MultipleActiveResultSets=true;";
            var options = new DbContextOptionsBuilder<OnlineShopDbContext>().UseSqlServer(OnlineShopTestConnection).Options;

            _dbContext = new OnlineShopDbContext(options);
            //********************************************************************

            _dbContext.Database.EnsureCreated();

            //*******************************************************************



            _categoryRepository = new CategoryRepository(_dbContext);


            SeedDatabase();
            var services = new ServiceCollection();


            services.AddMediatR(handlerAssembly);
            //services.AddMediatR((typeof(GetAllCategoryHandler).Assembly));
            //services.AddMediatR(FindAssembliesWithHandlers());

            services.AddScoped(_ => _dbContext);
            services.AddScoped(_ => _categoryRepository);


            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();





            _categoryController = new CategoryController(_mediator);



        }

        private void SeedDatabase()
        {
            // مقداردهی اولیه دیتابیس
            var hasData = _dbContext.Categories.Any(x => x.IsDelete == false);
            if (!hasData)
            {
                var m = new Filler<Category>().Create(10);
                _dbContext.Categories.AddRange(m);
                _dbContext.SaveChanges();
            }

        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}
