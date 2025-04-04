using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Handler.Query;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Command;
using OnlineShop.Application.Feature.CategoryBusiness.Request.Query;
using OnlineShop.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace OnlineShop.Api_UnitTest.OnlineShopApi.Controllers
{
    public class CategoryControllerTest
    {

        private readonly Mock<IMediator> _mediatorMock;
        private readonly CategoryController _controller;

        public CategoryControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CategoryController(_mediatorMock.Object);
        }

        [Fact]
        public async void GetCategoryTest()
        {
            Guid id = Guid.NewGuid();
            CategoryDto createCategoryDto = new Filler<CategoryDto>().Create();
            createCategoryDto.ID = id;

            //It.IsAny برای نمونه سازی با انعطاف پذیزی بیشتر از این گزینه استفاده میکنیم
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetCategoryRequest>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(createCategoryDto));


            var result = await _controller.GetCategory(id);
            var okResult = Assert.IsType<OkObjectResult>(result);


            Assert.Equal(createCategoryDto, okResult.Value);

            _mediatorMock.Verify(m => m.Send(It.IsAny<GetCategoryRequest>(), It.IsAny<CancellationToken>()), Times.Once);

        }


        [Fact]
        public async void GetAllCategoryTest()
        {
            // Arrange
            List<CategoryDto> lstCategoryDtos = new Filler<CategoryDto>().Create(10).ToList();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCategoryRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(lstCategoryDtos);


            //Act
            var result = await _controller.GetAllCategory();
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Assert
            Assert.Equal(lstCategoryDtos, okResult.Value);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAllCategoryRequest>(), It.IsAny<CancellationToken>()), Times.Once);

        }



        [Fact]
        public async void AddCategoryTest()
        {
            Guid id = Guid.NewGuid();
            CategoryDto createCategoryDto = new Filler<CategoryDto>().Create();
            //createCategoryDto.ID = Guid.Empty;

            
            var resultSuccessResult = Result<CategoryDto>.SuccessResult(createCategoryDto);
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateCategoryRequest>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(resultSuccessResult));


            var result = await _controller.AddCategory(createCategoryDto);
            var okResult = Assert.IsType<OkObjectResult>(result);
             

           Assert.IsType<OkObjectResult>(okResult);
           Assert.Equal(resultSuccessResult,okResult.Value);

        }




    }
}
