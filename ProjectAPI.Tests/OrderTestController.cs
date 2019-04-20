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
    public class OrderTestController
    {
        private ShopDataDbContext context;

        public static DbContextOptions<ShopDataDbContext>
        dbContextOptions
        { get; set; }
        public static string connectionString =
         "Data Source=TRD-517;Initial Catalog=ShoppingDemoooo2;Integrated Security=true;";
        static OrderTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShopDataDbContext>()
                .UseSqlServer(connectionString).Options;

        }
        public OrderTestController()
        {
            context = new ShopDataDbContext(dbContextOptions);

        }


        [Fact]
        public async void Task_GetOrderByID_Return_OkResult()
        {
            var controller = new OrdersController(context);
            var OrderId = 1;
            var Data = await controller.GetOrder(OrderId);
            Assert.IsType<OkObjectResult>(Data);
        }
        [Fact]
        public async void Task_GetOrderByID_Return_NotFoundResult()
        {
            var controller = new OrdersController(context);
            var OrderId = 6;
            var Data = await controller.GetOrder(OrderId);
            Assert.IsType<NotFoundResult>(Data);
        }
        //[Fact]
        //public async void Task_GetOrderByID_MatchResult()
        //{
        //    var controller = new OrdersController(context);
        //    int id = 1;
        //    var data = await controller.GetOrder(id);
        //    Assert.IsType<OkObjectResult>(data);
        //    var OkResult = data.Should().BeOfType<OkObjectResult>().Subject;
        //    var order = OkResult.Value.Should().BeAssignableTo<Order>().Subject;
        //    Assert.Equal(700, order.OrderPrice);
        //    Assert.Equal(2019 - 09 - 01, order.OrderDate);
        //    Assert.Equal(1, order.CustomerId);


        //}
        [Fact]
        public async void Task_GetOrderByID_BadResult()
        {
            var controller = new OrdersController(context);
            int? id = null;
            var data = await controller.GetOrder(id);
            Assert.IsType<BadRequestResult>(data);

        }
        //[Fact]
        //public async void Task_Add_AddOrder_Return_OkResult()
        //{ //Arrange
        //    var controller = new OrdersController(context);
        //    var order = new Order()
        //    {
        //        order.OrderPrice = 900,
        //    order.OrderDate = 2019 - 08 - 07,
        //    order.CustomerId = 2,


        //    };
        //    var data = await controller.Post(order);

        //    Assert.IsType<CreatedAtActionResult>(data);
        //}
        [Fact]
        public async void Task_DeleteOrder_Return_OkResult()
        {
            var controller = new OrdersController(context);
            var id = 5;
            //Act
            var data = await controller.DeleteOrder(id);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteOrder_Return_NotFound()
        {
            var controller = new OrdersController(context);
            var id = 13;
            //Act
            var data = await controller.DeleteOrder(id);
            //Assert
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_DeleteOrder_Return_BadResult()
        {
            var controller = new OrdersController(context);
            int? id = null;
            var data = await controller.DeleteOrder(id);
            Assert.IsType<BadRequestResult>(data);

        }

        //[Fact]
        //public async void Task_Put_OrderByID_MatchResult()
        //{
        //    var controller = new OrdersController(context);
        //    int id = 2;

        //    var order = new order()

        //    {
        //       OrderId = 1,
        //       OrderPrice = 1500,
        //        OrderDate = 2019 - 04 - 17,
        //       CustomerId = 1;

        //    };

        //    var data = await controller.PutOrder(id, order);
       
        //    Assert.IsType<OkObjectResult>(data);
        //}
     [Fact]
        public async void Task_Put_OrderByID_Return_NotFound()
        {
            var controller = new OrdersController(context);
            int? id = 8;
            var Order = new Order()

            {
                OrderId = 8,
                OrderPrice =1235 ,
               //OrderDate = 2018-9-9,
               CustomerId =2,
           
            };

            var data = await controller.PutOrder(id, Order);

            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_Put_OrderByID_Return_BadRequest()
        {
            var controller = new OrdersController(context);
            int? id = null;
            var Order = new Order()

            {
                OrderId = 1,
                OrderPrice = 1235,
                //OrderDate = 2018-9-9,
                CustomerId = 2,

            };

            var data = await controller.PutOrder(id, Order);

            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Return_GetAllOrders()
        {
            var controller = new OrdersController(context);
            var data = await controller.GetOrders();
            Assert.IsType<OkObjectResult>(data);
        }
    }
}

