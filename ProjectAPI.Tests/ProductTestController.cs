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
   public class ProductTestController
    {
        private ShopDataDbContext context;

        public static DbContextOptions<ShopDataDbContext>
        dbContextOptions
        { get; set; }
        public static string connectionString =
         "Data Source=TRD-517;Initial Catalog=ShoppingApisseDb5;Integrated Security=true;";
        static ProductTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShopDataDbContext>()
                .UseSqlServer(connectionString).Options;

        }
        public ProductTestController()
        {
            context = new ShopDataDbContext(dbContextOptions);

        }
        [Fact]

        public async void Task_GetProductByID_Return_OkResult()
        {
            var controller = new ProductController(context);
            var productId = 2;
            var Data = await controller.Get(productId);
            Assert.IsType<OkObjectResult>(Data);
        }
        [Fact]
        public async void Task_GetProductByID_Return_NotFoundResult()
        {
            var controller = new ProductController(context);
            var productId = 6;
            var Data = await controller.Get(productId);
            Assert.IsType<NotFoundResult>(Data);
        }
        [Fact]
        public async void Task_GetProductByID_MatchResult()
        {
            var controller = new ProductController(context);
            int id = 2;
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
            var OkResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var pro = OkResult.Value.Should().BeAssignableTo<Product>().Subject;
            Assert.Equal("Skirt", pro.ProductName);
            Assert.Equal(0, pro.ProductQty);
            Assert.Equal(1200, pro.ProductPrice);
            Assert.Equal("hi", pro.ProductImage);
            Assert.Equal("Linen Material", pro.ProductDescription);
            Assert.Equal(1,pro.VendorId);
            Assert.Equal(1, pro.ProductCategoryId);

        }
        [Fact]
        public async void Task_GetProductByID_BadResult()
        {
            var controller = new ProductController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);

        }
        [Fact]
        public async void Task_Add_AddProduct_Return_OkResult()
        { //Arrange
            var controller = new ProductController(context);
            var product = new Product()
            {
                ProductName = "Saree",
                ProductQty = 900,
                ProductPrice = 2000,
                ProductImage="Hii",
                ProductDescription = "Silk",
                VendorId=3,
                ProductCategoryId=1


            };
            var data = await controller.Post(product);

            Assert.IsType<CreatedAtActionResult>(data);
        }
        [Fact]
        public async void Task_DeleteProduct_Return_OkResult()
        {
            var controller = new ProductController(context);
            var id = 6;
            //Act
            var data = await controller.Delete(id);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteProduct_Return_NotFound()
        {
            var controller = new ProductController(context);
            var id = 13;
            //Act
            var data = await controller.Delete(id);
            //Assert
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_DeleteProduct_Return_BadResult()
        {
            var controller = new ProductController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Put_ProductByID_MatchResult()
        {
            var controller = new ProductController(context);
            int id = 2;

            var product = new Product()

            {
                ProductId = 2,
                ProductName = "Skirt",
                ProductPrice = 1200,
                ProductImage = "null",
                ProductDescription = "Linen Material",
                VendorId = 1,
                ProductCategoryId = 1


            };

            var data = await controller.Put(id, product);

            Assert.IsType<NoContentResult>(data);
        }
        [Fact]
        public async void Task_Put_ProductByID_Return_NotFound()
        {
            var controller = new ProductController(context);
            int? id = 15;
            var product = new Product()

            {
                ProductId = 2,
                ProductName = "Skirt",
                ProductPrice = 1200,
                ProductImage = "hi",
                ProductDescription = "Linen Material",
                VendorId = 1,
                ProductCategoryId = 1
            };

            var data = await controller.Put(id, product);

            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_Put_ProductByID_Return_BadRequest()
        {
            var controller = new ProductController(context);
            int? id = null;
            var productcategory = new Product()

            {
                ProductCategoryId = 4,
                ProductName = "Skirt",
                ProductPrice = 1299,
                ProductImage = null,

                ProductDescription = "Linen Material",
            };

            var data = await controller.Put(id, productcategory);

            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Return_GetAllProducts()
        {
            var controller = new ProductController(context);
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
