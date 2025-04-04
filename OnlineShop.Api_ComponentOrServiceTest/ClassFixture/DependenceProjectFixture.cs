
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Handler.Query;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Query;
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

namespace OnlineShop.Api_ComponentOrServiceTest.ClassFixture
{
    public class DependenceProjectFixture
    {
        public OnlineShopDbContext _dbContext;
        public IMediator _mediator { get; set; }
        public CategoryController _categoryController { get; set; }
        public ICategoryRepository _categoryRepository;



        public DependenceProjectFixture(params  Assembly[] handlerAssembly)
        {

            var options = new DbContextOptionsBuilder<OnlineShopDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _dbContext = new OnlineShopDbContext(options);
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
            var m = new Filler<Category>().Create(10);
            _dbContext.Categories.AddRange(m);
            _dbContext.SaveChanges();
        }


        public Assembly[] FindAssembliesWithHandlers()
        {
            // دریافت تمام اسمبلی‌های بارگذاری شده در دامنه برنامه
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // فیلتر اسمبلی‌هایی که حداقل یک نوع پیاده‌کننده IRequestHandler دارند
            assemblies = assemblies
                .Where(assembly => assembly.GetTypes()
                    .Any(type => type.GetInterfaces()
                        .Any(i => i.IsGenericType &&
                                  i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))))
                .ToArray();

            return assemblies;
        }


        public static Type[] FindAllHandlerTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToArray();
        }
    }
}
