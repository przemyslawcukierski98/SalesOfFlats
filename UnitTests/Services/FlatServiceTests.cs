using Application.Dto;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Services
{
    public class FlatServiceTests
    {
        [Fact]
        public async Task add_flat_async_should_invoke_add_async_on_flat_repository()
        {
            // Arrange
            var flatRepositoryMock = new Mock<IFlatRepository>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<FlatService>>();

            var flatService = new FlatService(flatRepositoryMock.Object,
                mapperMock.Object, loggerMock.Object);

            var flatDto = new CreateFlatDto()
            {
                Title = "Title 1",
                Description = "Description 1"
            };

            mapperMock.Setup(x => x.Map<Flat>(flatDto))
                .Returns(new Flat
                {
                    Title = flatDto.Title,
                    Description = flatDto.Description
                });

            // Act
            await flatService.AddNewFlatAsync(flatDto);

            // Assert
            flatRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Flat>()), Times.Once); ;
        }

        
    }
}

