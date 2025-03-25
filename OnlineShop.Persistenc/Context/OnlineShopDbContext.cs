using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Persistence.EntityValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Context
{
    public class OnlineShopDbContext:DbContext
    {

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //*****************************************************

            #region Fulent Api

            //modelBuilder.ApplyConfiguration<Category>(new CategoryValidation());
            //Assembly assemblyWithConfigurations = GetType().Assembly;           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//برای Fulent Api

            #endregion



            //*****************************************************

            #region Description For Clumns For SqlServer
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                    var descriptionAttribute = memberInfo?.GetCustomAttribute<DescriptionAttribute>();

                    if (descriptionAttribute != null)
                    {
                        property.SetComment(descriptionAttribute.Description);
                    }
                }
            }
            #endregion

            //******************************************************

            #region Default_Clumns_Sql_NEWID
            foreach (var entryType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IBaseEntity).IsAssignableFrom(t.ClrType)))
            {
                modelBuilder.Entity(entryType.ClrType).Property<Guid>("ID").ValueGeneratedNever().HasDefaultValueSql("NEWID()");
            }
            #endregion

            //******************************************************

            #region HasQueryFilter
            var softDeleteEntities = modelBuilder.Model.GetEntityTypes()
            .Where(t => typeof(IBaseEntity).IsAssignableFrom(t.ClrType));

            foreach (var entityType in softDeleteEntities)
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var filter = Expression.Lambda(
                    Expression.Not(Expression.Property(parameter, "IsDelete")),
                    parameter);

                modelBuilder.Entity(entityType.Name).HasQueryFilter(filter);
            }
            #endregion HasQueryFilter



            //*****************************************************

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

             

        }



        #region override SaveChanges
        //برای اینکه بتوانیم هنگام عملیات ذخیره تغییراتی در مدل بوجود بیاوریم
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries<IBaseEntity>().ToList())
            {
                if(item.State==EntityState.Added)
                {
                   // item.Entity.ID = Guid.NewGuid();
                }
            }
            return base.SaveChanges();  
        }
        #endregion




        public DbSet<Category> Categories { get; set; }


    }
}
