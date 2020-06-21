using AutoMapper;
using CBA.Training.Talmate.Api.Controllers;
using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Services.DemandService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Api.UnitTests
{
    [TestFixture]
    public class DemandControllerTests
    {
        private Mock<IDemandService> _mockDemandRepository;
        private Mock<IMapper> _mockMapperRepository;
        private DemandController _controller;
        [SetUp]
        public void Setup()
        {
            _mockDemandRepository = new Mock<IDemandService>();
            _mockMapperRepository = new Mock<IMapper>();
            _controller = new DemandController(_mockDemandRepository.Object, _mockMapperRepository.Object);
        }
        [Test]
        public async Task Get_CreatedDemand_ReturnsListOfDemandResource()
        {
            var result = await _controller.Get();

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

        }

        [Test]
        public async Task Post_IsDemandCreated_ReturnsTrue()
        {
            // Act
            _mockDemandRepository.Setup(repo => repo.Post(new Demand { PrimarySkills = "NET", SecondarySkills = "java", Location = "Pune", Start_By_Date = DateTime.Now, Experience = 10 }))
              .ReturnsAsync(true);
            var result = await _controller.Post(new Demand { PrimarySkills = "NET", SecondarySkills = "java", Location = "Pune", Start_By_Date = DateTime.Now, Experience = 10 });

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.Equals(true, result);

        }

        [Test]
        public async Task Post_IsDemandNull_ReturnsFalse()
        {
            // Act
            _mockDemandRepository.Setup(repo => repo.Post(null))
              .ReturnsAsync(false);
            var result = await _controller.Post(null);

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.Equals(false, result);

        }
    }
}
