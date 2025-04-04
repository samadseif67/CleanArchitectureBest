using OnlineShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace OnlineShop.Api_UnitTest.OnlineShopApplication.Dto
{
    public class ProductDtoTest
    {
        [Fact]
        public void ProductDto_Update_Test()
        {
            //Arrange --داده های پیش فرض را آماده میکنیم
            //Act   --عملیات که قرار هست انجام شود
            //Assert  --بررسی نتیجه


            //Arrange
            ProductDto productDto = new ProductDto()
            {
                ID=Guid.NewGuid(),  
                Title="Test1",
                Description= "Description"
            };


            //Act
            string Title = "Test2";
            productDto.UpdateTitle(Title);
             
            //Assert
            Assert.Equal(Title, productDto.Title);
            Assert.NotEmpty(productDto.Title);
            Assert.NotNull(productDto.Title);
        }

        [Fact]
        public void ProductDto_Update_Title_ExceptionEmpty()
        {
            //Filler با استفاده میتوان آبجکت پر شده ساخت
            ////Arrange
            var productDto = new Filler<ProductDto>().Create();

            //Act
            string Title = "";


            //Assert
            
            Assert.Throws<Exception>(() => productDto.UpdateTitle(Title));

        }

         

    }
}
