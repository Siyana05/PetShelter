using Moq;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Tests.Services
{
    public class ShelterServiceTests
    {
        private readonly Mock<IShelterRepository> _shelterRepositoryMock = new Mock<IShelterRepository>();
        private readonly IShelterService _service;
        private ShelterDto shelter;

        public ShelterServiceTests()
        {
            _service = new ShelterService(_shelterRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var shelterDto = new ShelterDto()
            {

                PetCapacity = 200,
                LocationId = 2


            };

            //Act
            await _service.SaveAsync(shelterDto);

            //Asert
            _shelterRepositoryMock.Verify(x => x.SaveAsync(shelterDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _shelterRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _shelterRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int shelterId)
        {
            //Arrange
            var shelterDto = new ShelterDto()
            {

                PetCapacity = 200,
                LocationId = 2
            };
            _shelterRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(shelterId))))
                .ReturnsAsync(shelterDto);
            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(shelterId);

            //Assert
            _shelterRepositoryMock.Verify(x => x.GetByIdAsync(shelterId), Times.Once);
            Assert.That(userResult == shelterDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int shelterId)
        {
            var shelterDto = (ShelterDto)default;
            _shelterRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(shelterId))))
                .ReturnsAsync(shelterDto);

            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(shelterId);

            //Assert
            _shelterRepositoryMock.Verify(x => x.GetByIdAsync(shelterId), Times.Once);
            Assert.That(userResult == shelter);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var shelterDto = new ShelterDto
            {
                PetCapacity = 200,
                LocationId = 2

            };
            _shelterRepositoryMock.Setup(s => s.SaveAsync(It.Is<ShelterDto>(x => x.Equals(shelterDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(shelterDto);

            //Assert
            _shelterRepositoryMock.Verify(x => x.SaveAsync(shelterDto), Times.Once);
        }

    }
}

