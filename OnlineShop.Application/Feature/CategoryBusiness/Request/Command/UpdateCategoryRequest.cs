using MediatR;
using OnlineShop.Application.Dto;
using OnlineShop.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryBusiness.Request.Command
{
    public class UpdateCategoryRequest:IRequest<Result<CategoryDto>>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
