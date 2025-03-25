using FluentValidation;
using OnlineShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ValidationDto
{
    public class CategoryDtoValidator:AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("عنوان الزامی می باشد").NotNull().WithMessage("عنوان الزامی می باشد");
            RuleFor(x => x.Description).NotEmpty().WithMessage("توضیحات الزامی می باشد").NotNull().WithMessage("توضیحات الزامی می باشد");

        }
    }
}
