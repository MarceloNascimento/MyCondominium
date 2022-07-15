using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Application.Commands.ApartmentInsert;

namespace Avanade.Challenge.MyCondominium.Tests
{
    public class ApartmentSaveOrUpdateCommandShould
    {
        private Mock<IApartmentRepository> MockApartmentRepository;
        private Mock<ILogger> _logger { get; set; }

        public ApartmentSaveOrUpdateCommandShould()
        {
            this._logger = new Mock<ILogger>();
            this.MockApartmentRepository = new Mock<IApartmentRepository>();
        }

        [Fact]
        public void SaveOrUpdateShouldReturnAparment()
        {
            //Arrange
            int apartmentId = 104;
            var createdIn = new DateTime(2022, 07, 14);
            var entity = new Apartment()
            {
                Id = apartmentId,
                Name = "104",
                Floor = "1",
                Block = "7",
                Created = createdIn,
                LastUpdated = createdIn
            };
                        
            var mockLogger = new Mock<ILogger>();
            var request = new ApartmentSaveOrUpdateRequest()
            {
                Id = entity.Id,
                Name = entity.Name,
                Block = entity.Block,
                Floor = entity.Floor
            };

            //Act
            MockApartmentRepository
                        .Setup(x => x.InsertAsync(entity, It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entity);

            MockApartmentRepository
                        .Setup(x => x.UpdateAsync(entity, It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entity);

            MockApartmentRepository
                        .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entity);

            var sut = new ApartmentSaveOrUpdateCommand(mockLogger.Object,
                                            this.MockApartmentRepository.Object);

            var response = sut.Handle(request, It.IsAny<CancellationToken>());

            //Asserts
            response.Result.Should().NotBeNull();
            response.Result.Should().BeOfType(typeof(ApartmentSaveOrUpdateViewModel));
        }
    }
}