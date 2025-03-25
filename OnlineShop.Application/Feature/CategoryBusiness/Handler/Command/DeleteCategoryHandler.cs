using MediatR;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Command;
using OnlineShop.Common.Common;
using OnlineShop.Domain.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryBusiness.Handler.Command
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Result<bool>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<bool>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            Guid CategoryID = request.CategoryID;
            var Result = await _categoryRepository.Delete(CategoryID);
            return Result<bool>.SuccessResult(Result);

        }
    }
}
