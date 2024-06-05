using Microsoft.Identity.Client;
using Moq;
using PetShelter.Data.Entities;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Enums;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Tests.Services
{
    public class BreedsServiceTests 
    {
        private readonly Mock<IBreedRepository> _breedRepositoryMock = new Mock<IBreedRepository>();
        private readonly IBreedsService _service;
        private BreedDto breed;

        public BreedsServiceTests()
        {
            _service = new BreedsService(_breedRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var breedDto = new BreedDto()
            {
                Id = 0,
                Name = "Pug",
                Size = BreedSize.Small

            };

            //Act
            await _service.SaveAsync(breedDto);

            //Asert
            _breedRepositoryMock.Verify(x => x.SaveAsync(breedDto), Times.Once());

            
           
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async() => await _service.SaveAsync(null));
            _breedRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            //Arrange

            //Act
            await _service.DeleteAsync(id);

            //Assert
            _breedRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int breedId)
        {
            //Arrange
            var breedDto = new BreedDto()
            {
                Id = breedId,
                Name = "Pug",
                Size = BreedSize.Small
            };
            _breedRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(breedId))))
                .ReturnsAsync(breedDto);
            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(breedId);

            //Assert
            _breedRepositoryMock.Verify(x => x.GetByIdAsync(breedId), Times.Once);
            Assert.That(userResult == breedDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int breedId)
        {
            var breedDto = (BreedDto) default;
            _breedRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(breedId))))
                .ReturnsAsync(breedDto);

            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(breedId);

            //Assert
            _breedRepositoryMock.Verify(x => x.GetByIdAsync(breedId), Times.Once);
            Assert.That(userResult == breed);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var breedDto = new BreedDto
            {
                Id = 1,
                Name = "Pug",
                Size = BreedSize.Small

            };
            _breedRepositoryMock.Setup(s => s.SaveAsync(It.Is<BreedDto>(x => x.Equals(breedDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(breedDto);

            //Assert
            _breedRepositoryMock.Verify(x => x.SaveAsync(breedDto), Times.Once);
        }

    }
}
