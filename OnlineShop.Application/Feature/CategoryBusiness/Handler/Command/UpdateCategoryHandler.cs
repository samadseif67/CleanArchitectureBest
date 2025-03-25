using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Command;
using OnlineShop.Application.ValidationDto;
using OnlineShop.Common.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryBusiness.Handler.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Result<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;     
        }
        public async Task<Result<CategoryDto>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {

            CategoryDtoValidator categoryDtoValidator = new CategoryDtoValidator();
            var LstError = categoryDtoValidator.Validate(request.CategoryDto).Errors.Select(x => x.ErrorMessage).ToList();
            if (LstError.Count() != 0)
            {
                return Result<CategoryDto>.ErrorResult(null, LstError);
            }

            CategoryDto categoryDto = request.CategoryDto;
            Category category = AutoMapperConvert.ConfigMap<CategoryDto, Category>(categoryDto);
            var Updated =await _categoryRepository.Update(category);
            var Result = AutoMapperConvert.ConfigMap<Category, CategoryDto>(Updated);
            return Result<CategoryDto>.SuccessResult(Result);
        }
    }
}
