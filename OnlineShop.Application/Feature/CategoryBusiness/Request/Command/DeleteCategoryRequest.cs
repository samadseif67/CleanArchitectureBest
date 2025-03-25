using MediatR;
using OnlineShop.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryBusiness.Request.Command
{
    public class DeleteCategoryRequest:IRequest<Result<bool>>
    {
        public Guid CategoryID { get; set; }
    }
}
