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
    public class PetVaccineServiceTests
    {
        private readonly Mock<IPetVaccineRepository> _petvaccineRepositoryMock = new Mock<IPetVaccineRepository>();
        private readonly IPetVaccineService _service;
        private PetVaccineDto petvaccine;

        public PetVaccineServiceTests()
        {
            _service = new PetVaccineService(_petvaccineRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petvaccineDto = new PetVaccineDto()
            {
                VaccineId = 0,
                PetId = 2

            };

            //Act
            await _service.SaveAsync(petvaccineDto);

            //Asert
            _petvaccineRepositoryMock.Verify(x => x.SaveAsync(petvaccineDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _petvaccineRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _petvaccineRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int petvaccineId)
        {
            //Arrange
            var petvaccineDto = new PetVaccineDto()
            {
                VaccineId = 0,
                PetId = 2
            };
            _petvaccineRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(petvaccineId))))
                .ReturnsAsync(petvaccineDto);
            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(petvaccineId);

            //Assert
            _petvaccineRepositoryMock.Verify(x => x.GetByIdAsync(petvaccineId), Times.Once);
            Assert.That(userResult == petvaccineDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int petvaccineId)
        {
            var petDto = (PetVaccineDto)default;
            _petvaccineRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(petvaccineId))))
                .ReturnsAsync(petDto);

            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(petvaccineId);

            //Assert
            _petvaccineRepositoryMock.Verify(x => x.GetByIdAsync(petvaccineId), Times.Once);
            Assert.That(userResult == petvaccine);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petvaccineDto = new PetVaccineDto
            {
                VaccineId = 0,
                PetId = 2

            };
            _petvaccineRepositoryMock.Setup(s => s.SaveAsync(It.Is<PetVaccineDto>(x => x.Equals(petvaccineDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(petvaccineDto);

            //Assert
            _petvaccineRepositoryMock.Verify(x => x.SaveAsync(petvaccineDto), Times.Once);
        }

    }
}

