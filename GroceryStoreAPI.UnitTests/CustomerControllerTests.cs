using Xunit;
using GroceryStoreAPI.Abstract;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GroceryStoreAPI.Entities;

namespace GroceryStoreAPI.Controllers
{
    public class CustomerControllerTests
    {
        CustomerController _controller;
        ICustomerService _service;

        public CustomerControllerTests()
        {
            _service = new CustomerService();
            _controller = new CustomerController(_service);
        }

        // Testing the GetAllCustomers Method
        [Fact]
        public void GetAllCustomers_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllCustomers();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetAllCustomers_WhenCalled_ReturnsAllCustomers()
        {
            // Act
            var okResult = _controller.GetAllCustomers().Result as OkObjectResult;
            // Assert
            var allCustomers = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Equal(3, allCustomers.Count);

        }

        // Testing the GetCustomerById Method
        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetCustomerById(4);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetCustomerById_ExistingIdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetCustomerById(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetCustomerById_ExistingIdPassed_ReturnsRightCustomer()
        {
            //Arrange
            var testCustomer = new Customer() { Id = 3, Name = "Joe" };

            // Act
            var okResult = _controller.GetCustomerById(3).Result as OkObjectResult;

            // Assert
            Assert.IsType<Customer>(okResult.Value);
            Assert.Equal(testCustomer.Id, (okResult.Value as Customer).Id);
            Assert.Equal(testCustomer.Name, (okResult.Value as Customer).Name);
        }

        // Testing the AddCustomer Method
        [Fact]
        public void AddCustomer_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var newCustomer = new Customer() { };

            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.AddCustomer(newCustomer);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void AddCustomer_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var newCustomer = new Customer()
            {
                Name = "Jasper"
            };

            // Act
            var createResponse = _controller.AddCustomer(newCustomer);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createResponse);
        }

        [Fact]
        public void AddCustomer_ValidObjectPassed_ReturnsResponseHasCreatedItem()
        {
            // Arrange
            var newCustomer = new Customer()
            {
                Name = "Jasper"
            };

            // Act
            var createResponse = _controller.AddCustomer(newCustomer) as CreatedAtActionResult;
            var customer = createResponse.Value as Customer;

            // Assert
            Assert.Equal(newCustomer.Name, customer.Name);
        }


        // Testing the UpdateCustomerById Method
        [Fact]
        public void UpdateCustomerById_ValidObjectPassed_ReturnOkResult()
        {
            // Arrange
            var newCustomer = new Customer()
            {
                Id = 3,
                Name = "Jasper"
            };

            // Act
            var okResult = _controller.UpdateCustomerById(newCustomer);

            // Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public void UpdateCustomerById_CustomerNotExist_ReturnNotFoundResult()
        {
            // Arrange
            var newCustomer = new Customer()
            {
                Id = 0,
                Name = "Andy"
            };

            // Act
            var notFoundResult = _controller.UpdateCustomerById(newCustomer);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
