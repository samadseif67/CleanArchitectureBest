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
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
       

        public GetCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }



        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            Guid CategoryID = request.CategoryID;
            var FindCategory = await _categoryRepository.Get(CategoryID);            
            var Result =AutoMapperConvert.ConfigMap<Category, CategoryDto>(FindCategory);
            return Result;
        }
    }
}
