using MediatR;
using OnlineShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryBusiness.Request.Query
{
    public class GetCategoryRequest:IRequest<CategoryDto>
    {
        public Guid CategoryID { get; set; }
    }
}
