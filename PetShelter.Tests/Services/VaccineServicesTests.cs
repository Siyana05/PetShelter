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
    public class VaccineServicesTests
    {

        private readonly Mock<IVaccineRepository> _vaccineRepositoryMock = new Mock<IVaccineRepository>();
        private readonly IVaccineService _service;
        private VaccineDto vaccine;

        public VaccineServicesTests()
        {
            _service = new VaccineService(_vaccineRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var vaccineDto = new VaccineDto()
            {
                Name = "Test",
                Description = "Strong medicine"

            };

            //Act
            await _service.SaveAsync(vaccineDto);

            //Asert
            _vaccineRepositoryMock.Verify(x => x.SaveAsync(vaccineDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _vaccineRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _vaccineRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int vaccineId)
        {
            //Arrange
            var vaccineDto = new VaccineDto()
            {
                Name = "Test",
                Description = "Strong medicine"
            };
            _vaccineRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(vaccineId))))
                .ReturnsAsync(vaccineDto);
            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(vaccineId);

            //Assert
            _vaccineRepositoryMock.Verify(x => x.GetByIdAsync(vaccineId), Times.Once);
            Assert.That(userResult == vaccineDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int vaccineId)
        {
            var vaccineDto = (VaccineDto)default;
            _vaccineRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(vaccineId))))
                .ReturnsAsync(vaccineDto);

            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(vaccineId);

            //Assert
            _vaccineRepositoryMock.Verify(x => x.GetByIdAsync(vaccineId), Times.Once);
            Assert.That(userResult == vaccine);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var vaccineDto = new VaccineDto
            {
                Name = "Test",
                Description = "Strong medicine"

            };
            _vaccineRepositoryMock.Setup(s => s.SaveAsync(It.Is<VaccineDto>(x => x.Equals(vaccineDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(vaccineDto);

            //Assert
            _vaccineRepositoryMock.Verify(x => x.SaveAsync(vaccineDto), Times.Once);
        }

    }
}

