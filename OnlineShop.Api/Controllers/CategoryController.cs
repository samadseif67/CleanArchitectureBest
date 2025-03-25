using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Command;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Query;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")] 
    public class CategoryController : ControllerBase
    {


        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategory(Guid CategoryID)
        {
            var result = await _mediator.Send(new GetCategoryRequest() { CategoryID = CategoryID });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetAllCategoryRequest());
            return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryDto categoryDto)
        {
            var result = await _mediator.Send(new CreateCategoryRequest() { CategoryDto = categoryDto });
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            var result = await _mediator.Send(new UpdateCategoryRequest() { CategoryDto = categoryDto });
            return Ok(result);
        }







    }
}
