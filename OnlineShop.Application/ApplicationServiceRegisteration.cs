using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Dto;
using OnlineShop.Application.ValidationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection ApplicationConfig(this IServiceCollection services)
        {

            #region MediatR

            services.AddMediatR(Assembly.GetExecutingAssembly());

            #endregion


            #region AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion


            #region FluentValidation

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // یا اسم اسمبلی مربوطه


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    return new BadRequestObjectResult(new
                    {
                        Message = "Validation errors occurred.",
                        Errors = errors
                    });
                };
            });

            #endregion


            return services;
        }
    }
}
