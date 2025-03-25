using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Command;
using OnlineShop.Domain.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;
using OnlineShop.Common.Common;
using OnlineShop.Application.ValidationDto;

namespace OnlineShop.Application.Feature.CategoryBusiness.Handler.Command
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Result<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository categoryRepository )
        {
            _categoryRepository = categoryRepository;     
        }

        public async Task<Result<CategoryDto>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {

            CategoryDtoValidator categoryDtoValidator = new CategoryDtoValidator();
            var LstError = categoryDtoValidator.Validate(request.CategoryDto).Errors.Select(x => x.ErrorMessage).ToList();
            if (LstError.Count() != 0)
            {
                return Result<CategoryDto>.ErrorResult(null, LstError);
            }

            CategoryDto categoryDto = request.CategoryDto;
            Category category = AutoMapperConvert.ConfigMap<CategoryDto,Category>(categoryDto);
            var Insert = await _categoryRepository.Add(category);
            var Result = AutoMapperConvert.ConfigMap<Category, CategoryDto>(Insert);
            return Result<CategoryDto>.SuccessResult(Result);
        }
    }
}
