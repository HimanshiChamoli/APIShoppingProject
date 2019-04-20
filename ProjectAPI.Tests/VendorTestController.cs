//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ProjectAPI.Controllers;
//using ProjectAPI.Models;
//using System;
//using Xunit;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Controllers;
using ProjectAPI.Models;
using Xunit;

namespace ProjectAPI.Tests
{
    public class VendorTestController
    {
        private ShopDataDbContext context;

        public static DbContextOptions<ShopDataDbContext>
        dbContextOptions
        { get; set; }



        public static string connectionString =
           "Data Source=TRD-517;Initial Catalog=ShoppingDemoooo2;Integrated Security=true;";
        static VendorTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShopDataDbContext>()
                .UseSqlServer(connectionString).Options;

        }
        public VendorTestController()
        {
            context = new ShopDataDbContext(dbContextOptions);

        }
        [Fact]

        public async void Task_GetVendorByID_Return_OkResult()
        {
            var controller = new VendorController(context);
            var VendorId = 1;
            var Data = await controller.Get(VendorId);
            Assert.IsType<OkObjectResult>(Data);
        }
        [Fact]
        public async void Task_GetVendorByID_Return_NotFoundResult()
        {
            var controller = new VendorController(context);
            var VendorId = 6;
            var Data = await controller.Get(VendorId);
            Assert.IsType<NotFoundResult>(Data);
        }
        [Fact]
        public async void Task_GetVendorByID_MatchResult()
        {
            var controller = new VendorController(context);
            int id = 1;
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
            var OkResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var ven = OkResult.Value.Should().BeAssignableTo<Vendor>().Subject;
            Assert.Equal("Himanshi", ven.VendorName);
            Assert.Equal("himi@gmail.com", ven.EmailId);
            Assert.Equal("Deliver the product on time", ven.VendorDescription);
        }
        [Fact]
        public async void Task_GetVendorByID_BadResult()
        {
            var controller = new VendorController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);

        }
        [Fact]
        public async void Task_Add_AddVendor_Return_OkResult()
        { //Arrange
            var controller = new VendorController(context);
            var vendor = new Vendor()
            {
                VendorName = "Noori",
                EmailId = "Noori@gmail.com",
                PhoneNo = 9088987678,
                VendorDescription = "Efficient!"
            };
            var data = await controller.Post(vendor);

            Assert.IsType<CreatedAtActionResult>(data);
        }
        [Fact]
        public async void Task_Add_Invalid_AddVendor_Return_OkResult_BadRequest()
        { //Arrange
            var controller = new VendorController(context);
            var vendor = new Vendor()
            {
                VendorName = "Noor",
                EmailId = "Noor1@gmail.com",
                PhoneNo = 128974575,
                VendorDescription = "Great!"
            };
            var data = await controller.Post(vendor);

            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_DeleteVendor_Return_OkResult()
        {
            var controller = new VendorController(context);
            var id = 3;
            //Act
            var data = await controller.Delete(id);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_DeleteVendor_Return_NotFound()
        {
            var controller = new VendorController(context);
            var id = 13;
            //Act
            var data = await controller.Delete(id);
            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_DeleteVendor_Return_BadResult()
        {
            var controller = new VendorController(context);
            int? id = null;
            var data = await controller.Delete(id);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Put_VendorByID_MatchResult()
        {
            var controller = new VendorController(context);
            int id = 2;

            var Vendor = new Vendor()

            {
                VendorId = 2,
                VendorName = "Noori",
                EmailId = "Noori@gmail.com",
                PhoneNo = 9088987678,
                VendorDescription = "Efficient!"
            };

            var data = await controller.Put(id, Vendor);

            Assert.IsType<NoContentResult>(data);
        }
        [Fact]
        public async void Task_Put_VendorByID_Return_NotFound()
        {
            var controller = new VendorController(context);
            int? id = 15;

            var Vendor = new Vendor()

            {
                VendorId = 14,
                VendorName = "Shimi",
                EmailId = "shimi@gmail.com",
                PhoneNo = 98652142478,
                VendorDescription = "Super!"
            };

            var data = await controller.Put(id, Vendor);

            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_Put_VendorByID_Return_BadRequest()
        {
            var controller = new VendorController(context);
            int? id = null;

            var Vendor = new Vendor()

            {

                VendorName = "Shimi",
                EmailId = "shimi@gmail.com",
                PhoneNo = 98652142478,
                VendorDescription = "Super!"
            };

            var data = await controller.Put(id, Vendor);

            Assert.IsType<BadRequestResult>(data);
        }
    }
}



