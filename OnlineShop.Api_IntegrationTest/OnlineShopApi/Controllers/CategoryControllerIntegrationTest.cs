using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api_IntegrationTest.ClassFixture;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Feature.CategoryBusiness.Handler.Command;
using OnlineShop.Application.Feature.CategoryBusiness.Handler.Query;
using OnlineShop.Application.ValidationDto;
using OnlineShop.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace OnlineShop.Api_IntegrationTest.OnlineShopApi.Controllers
{
    public class CategoryControllerIntegrationTest
    {
        public readonly DependenceProjectFixtureIntegration fixture;
        public CategoryControllerIntegrationTest()
        {
            fixture = new DependenceProjectFixtureIntegration(
                typeof(GetAllCategoryHandler).Assembly,
                typeof(GetCategoryHandler).Assembly,
                typeof(CreateCategoryHandler).Assembly
                );
        }


        [Fact]
        public async void GetAllCategory_ComponentTest()
        {

            var result = await fixture._categoryController.GetAllCategory();
            var okResult = result as OkObjectResult;
            var lstCategoryDto = okResult.Value as List<CategoryDto>;


            Assert.IsType<List<CategoryDto>>(lstCategoryDto);
            Assert.NotNull(result);
            Assert.NotEmpty(lstCategoryDto);
        }

        [Fact]
        public async void GetCategory_ComponentTest()
        {
            var find = fixture._dbContext.Categories.FirstOrDefault();
            Guid categoryId = find.ID;

            var result = await fixture._categoryController.GetCategory(categoryId);
            var okResult = result as OkObjectResult;
            var lstCategoryDto = okResult.Value as CategoryDto;


            Assert.IsType<CategoryDto>(lstCategoryDto);
            Assert.NotNull(result);

        }

        [Fact]
        public async void AddCategory_ComponentTest()
        {
            //Arrange
            CategoryDto categoryDto = new Filler<CategoryDto>().Create();
            categoryDto.ID = Guid.Empty;

            //Act
            var result = await fixture._categoryController.AddCategory(categoryDto);
            var okResult = result as OkObjectResult;
            Result<CategoryDto> result1 = okResult.Value as Result<CategoryDto>;

            Guid categoryId = result1.Data.ID;
            var find = fixture._dbContext.Categories.FirstOrDefault(x => x.IsDelete == false && x.ID == categoryId);


            //اعتبار سنجی داده ها
            var validator = new CategoryDtoValidator();
            var resultValidator = validator.Validate(categoryDto);




            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(categoryDto.Title, find.Title);
            Assert.Equal(categoryDto.Description, find.Description);
            Assert.True(resultValidator.IsValid);

        }



    }
}
