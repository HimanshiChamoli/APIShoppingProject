using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Controllers;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProjectAPI.Tests
{
    public class ProductCategoryTestController
    {
        private ShopDataDbContext context;

        public static DbContextOptions<ShopDataDbContext>
        dbContextOptions
        { get; set; }

        public static string connectionString =
          "Data Source=TRD-517;Initial Catalog=ShoppingApisseDb5;Integrated Security=true;";
        static ProductCategoryTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShopDataDbContext>()
                .UseSqlServer(connectionString).Options;

        }

        public ProductCategoryTestController()
        {
            context = new ShopDataDbContext(dbContextOptions);

        }

       

        [Fact]

        public async void Task_GetProductCategoryByID_Return_OkResult()
        {
            var controller = new ProductCategoryController(context);
            var productcategoryId = 1;
            var Data = await controller.Get(productcategoryId);
            Assert.IsType<OkObjectResult>(Data);
        }
        [Fact]
        public async void Task_GetProductCategoryByID_Return_NotFoundResult()
        {
            var controller = new ProductCategoryController(context);
            var productcategoryId = 6;
            var Data = await controller.Get(productcategoryId);
            Assert.IsType<NotFoundResult>(Data);
        }
        [Fact]
        public async void Task_GetProductCategoryByID_MatchResult()
        {
            var controller = new ProductCategoryController(context);
            int id = 1;
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
            var OkResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var pro = OkResult.Value.Should().BeAssignableTo<ProductCategory>().Subject;
            Assert.Equal("Summer Collection", pro.CategoryName);
            Assert.Equal("Cotton Collection", pro.CategoryDescription);

        }
        [Fact]
        public async void Task_GetProductCategoryByID_BadResult()
        {
            var controller = new ProductCategoryController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);

        }
        [Fact]
        public async void Task_Add_AddProductCategory_Return_OkResult()
        { //Arrange
            var controller = new ProductCategoryController(context);
            var productcategory = new ProductCategory()
            {
                CategoryName = "Spring Collection",
                CategoryDescription = "Floral Material"
               
            };
            var data = await controller.Post(productcategory);

            Assert.IsType<CreatedAtActionResult>(data);
        }
        //[Fact]
        //public async void Task_Add_Invalid_AddVendor_Return_OkResult_BadRequest()
        //{ //Arrange
        //    var controller = new VendorController(context);
        //    var vendor = new Vendor()
        //    {
        //        VendorName = "Noor",
        //        EmailId = "Noor1@gmail.com",
        //        PhoneNo = 128974575,
        //        VendorDescription = "Great!"
        //    };
        //    var data = await controller.Post(vendor);

        //    Assert.IsType<BadRequestResult>(data);
        //}
        [Fact]
        public async void Task_DeleteProductCategory_Return_OkResult()
        {
            var controller = new ProductCategoryController(context);
            var id = 3;
            //Act
            var data = await controller.Delete(id);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteProductCategory_Return_NotFound()
        {
            var controller = new ProductCategoryController(context);
            var id = 13;
            //Act
            var data = await controller.Delete(id);
            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_DeleteProductCategory_Return_BadResult()
        {
            var controller = new ProductCategoryController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Put_ProductCategoryByID_MatchResult()
        {
            var controller = new ProductCategoryController(context);
            int id = 2;

            var productcategory = new ProductCategory()

            {
                ProductCategoryId = 2,
                CategoryName = "Autmn Collections",
                CategoryDescription = "Floral Collection",
               
            };

            var data = await controller.Put(id, productcategory);

            Assert.IsType<NoContentResult>(data);
        }
        [Fact]
        public async void Task_Put_ProductCategoryByID_Return_NotFound()
        {
            var controller = new ProductCategoryController(context);
            int? id = 15;
            var productcategory = new ProductCategory()

            {
                ProductCategoryId = 2,
                CategoryName = "Autmn Collections",
                CategoryDescription = "Floral Collection",
            };

            var data = await controller.Put(id, productcategory);

            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_Put_ProductCategoryByID_Return_BadRequest()
        {
            var controller = new ProductCategoryController(context);
            int? id = null;
            var productcategory = new ProductCategory()

            {
                ProductCategoryId = 2,
                CategoryName = "Autmn Collections",
                CategoryDescription = "Floral Collection",
            };

            var data = await controller.Put(id, productcategory);

            Assert.IsType<BadRequestResult>(data);
        }
    }
}
