using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using API.Persistence.Repositories;
using API.Controllers;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;


namespace Tests.Controller
{
    public class ComputerControllerTests
    {
        private Mock<IComputerRepository> _mockService;
        private ComputerController _controller;

        public ComputerControllerTests()
        {
            _mockService = new Mock<IComputerRepository>();
            _controller = new ComputerController(_mockService.Object);
        }

        [Fact]
        public void GetComputer_ReturnsOkResult_WithComputer()
        {
            int testId = 1;
            Computer testComputer = new Computer(testId, "Test Brand", "Test Model", 2020);

            _mockService.Setup(x => x.GetComputer(testId)).Returns(testComputer);

            // Act
            var result = _controller.GetComputer(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsType<Computer>(okResult.Value);

            Assert.Equal("Test Brand", returnValue.Brand);
        }

                [Fact]
        public void GetComputer_ReturnsNotFound_WithComputer()
        {
            int testId = 1;
            Computer testComputer = new Computer(testId, "Test Brand", "Test Model", 2020);

            _mockService.Setup(x => x.GetComputer(testId)).Returns(testComputer);

            // Act
            var result = _controller.GetComputer(2);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);

            Assert.Equal("Microsoft.AspNetCore.Mvc.NotFoundResult", notFoundResult.ToString());
        }

        [Fact]
        public void PostComputer_ReturnsCreatedAtAction_WithComputer()
        {
            // Arrange

            AddComputerDTO model = new AddComputerDTO("Test Brand", "Test Model", 2023);

            Computer computer = new Computer(model.Brand, model.Model, model.Year);

            _mockService.Setup(service => service.AddComputer(computer));

            // Act

            var result = _controller.Post(model);

            // Assert

            var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);

            var returnValue = Assert.IsType<Computer>(createdAtAction);

            Assert.Equal("Test Brand", returnValue.Brand);



        }

        [Fact]
        public void Put()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void Delete()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}