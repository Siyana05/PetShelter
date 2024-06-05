using Moq;
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
    public class PetServiceTests
    {
        private readonly Mock<IPetRepository> _petRepositoryMock = new Mock<IPetRepository>();
        private readonly IPetService _service;
        private PetDto pet;

        public PetServiceTests()
        {
            _service = new PetService(_petRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petDto = new PetDto()
            {
                Id = 0,
                Name = "Ari",
                Color = "White",
                IsAdopted = true,
                IsEuthanized = true,
                PetTypeId = 1,
                BreedId = 2,
                AdopterId = 3,
                GiverId = 4,
                ShelterId = 5

            };

            //Act
            await _service.SaveAsync(petDto);

            //Asert
            _petRepositoryMock.Verify(x => x.SaveAsync(petDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _petRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _petRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int petId)
        {
            //Arrange
            var petDto = new PetDto()
            {
                Id = 0,
                Name = "Ari",
                Color = "White",
                IsAdopted = true,
                IsEuthanized = true,
                PetTypeId = 1,
                BreedId = 2,
                AdopterId = 3,
                GiverId = 4,
                ShelterId = 5
            };
            _petRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(petId))))
                .ReturnsAsync(petDto);
            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(petId);

            //Assert
            _petRepositoryMock.Verify(x => x.GetByIdAsync(petId), Times.Once);
            Assert.That(userResult == petDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int petId)
        {
            var petDto = (PetDto)default;
            _petRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(petId))))
                .ReturnsAsync(petDto);

            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(petId);

            //Assert
            _petRepositoryMock.Verify(x => x.GetByIdAsync(petId), Times.Once);
            Assert.That(userResult == pet);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petDto = new PetDto
            {
                Id = 0,
                Name = "Ari",
                Color = "White",
                IsAdopted = true,
                IsEuthanized = true,
                PetTypeId = 1,
                BreedId = 2,
                AdopterId = 3,
                GiverId = 4,
                ShelterId = 5

            };
            _petRepositoryMock.Setup(s => s.SaveAsync(It.Is<PetDto>(x => x.Equals(petDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(petDto);

            //Assert
            _petRepositoryMock.Verify(x => x.SaveAsync(petDto), Times.Once);
        }

    }
}

