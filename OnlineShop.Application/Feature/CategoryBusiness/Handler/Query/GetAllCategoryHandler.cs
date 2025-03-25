using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Query;
using OnlineShop.Common.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryBusiness.Handler.Query
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        
         
        public GetAllCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;          
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var lstCategory = _categoryRepository.GetAll().ToList();
            var Result = AutoMapperConvert.ConfigMapList<Category, CategoryDto>(lstCategory); 
            return Result;
        }
    }
}
