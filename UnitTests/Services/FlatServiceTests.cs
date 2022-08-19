using Application.Dto;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
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
            flatRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Flat>()), Times.Once); 
        }

        [Fact]
        public async Task when_invoking_get_flat_async_if_should_invoke_get_async_on_flat_repository()
        {
            // Arrange
            var flatRepositoryMock = new Mock<IFlatRepository>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<FlatService>>();

            var flatService = new FlatService(flatRepositoryMock.Object,
                mapperMock.Object, loggerMock.Object);

            var flat = new Flat(1, "Title 1", "Description 1", 30, 1, 100000, "Własne", 1, "Stan surowy", "brak", "brak", "miejskie");
            var flatDto = new FlatDto()
            {
                Id = flat.Id,
                Title = flat.Title,
                Description = flat.Description,
                Area = flat.Area,
                NumberOfRooms = flat.NumberOfRooms,
                Price = flat.Price,
                Floor = flat.Floor
            };

            flatRepositoryMock.Setup(x => x.GetFlatByIdAsync(flat.Id)).ReturnsAsync(flat);

            // Act
            var existingFlatDto = await flatService.GetFlatByIdAsync(flat.Id);

            // Assert
            flatRepositoryMock.Verify(x => x.GetFlatByIdAsync(flat.Id), Times.Once);
            flatDto.Should().NotBeNull();
            flatDto.Title.Should().NotBeNull();
            flatDto.Title.Should().BeEquivalentTo(flat.Title);
            flatDto.Description.Should().NotBeNull();
            flatDto.Description.Should().BeEquivalentTo(flat.Description);
        }
    }
}

