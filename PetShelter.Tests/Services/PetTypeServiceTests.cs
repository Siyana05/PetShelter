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
    public class PetTypeServiceTests
    {
        private readonly Mock<IPetTypeRepository> _pettypeRepositoryMock = new Mock<IPetTypeRepository>();
        private readonly IPetTypeService _service;
        private PetTypeDto pettype;

        public PetTypeServiceTests()
        {
            _service = new PetTypeService(_pettypeRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var pettypeDto = new PetTypeDto()
            {
                Name = "Izi"
                
            };

            //Act
            await _service.SaveAsync(pettypeDto);

            //Asert
            _pettypeRepositoryMock.Verify(x => x.SaveAsync(pettypeDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _pettypeRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _pettypeRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int pettypeId)
        {
            //Arrange
            var pettypeDto = new PetTypeDto()
            {
                Name = "Izi",
               
            };
            _pettypeRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(pettypeId))))
                .ReturnsAsync(pettypeDto);
            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(pettypeId);

            //Assert
            _pettypeRepositoryMock.Verify(x => x.GetByIdAsync(pettypeId), Times.Once);
            Assert.That(userResult == pettypeDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int pettypeId)
        {
            var petDto = (PetTypeDto)default;
            _pettypeRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(pettypeId))))
                .ReturnsAsync(petDto);

            //Act
            var userResult = await _service.GeyByIdIfExistsAsync(pettypeId);

            //Assert
            _pettypeRepositoryMock.Verify(x => x.GetByIdAsync(pettypeId), Times.Once);
            Assert.That(userResult == pettype);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var pettypeDto = new PetTypeDto
            {
                Name = "Izi",

            };
            _pettypeRepositoryMock.Setup(s => s.SaveAsync(It.Is<PetTypeDto>(x => x.Equals(pettypeDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(pettypeDto);

            //Assert
            _pettypeRepositoryMock.Verify(x => x.SaveAsync(pettypeDto), Times.Once);
        }

    }
}

