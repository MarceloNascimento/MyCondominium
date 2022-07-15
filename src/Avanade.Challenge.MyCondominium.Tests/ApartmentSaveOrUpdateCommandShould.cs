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

        public ApartmentSaveOrUpdateCommandShould(ILogger logger
            , IApartmentRepository apartmentRepository)
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

            Task<Apartment> taskApartment = Task.FromResult(entity);
            var logger = new Mock<ILogger>();
            var request = new ApartmentSaveOrUpdateRequest()
            {
                Id = entity.Id,
                Name = entity?.Name,
                Block = entity?.Block,
                Floor = entity?.Floor
            };

            //Act
            _ = MockApartmentRepository
                        .Setup(x => x.InsertAsync(entity, It.IsAny<CancellationToken>()))
                        .Returns(taskApartment);

            _ = MockApartmentRepository
                        .Setup(x => x.UpdateAsync(entity, It.IsAny<CancellationToken>()))
                        .Returns(taskApartment);

            var sut = new ApartmentSaveOrUpdateCommand(logger.Object,
                                            this.MockApartmentRepository.Object);

            var response = sut.Handle(request, It.IsAny<CancellationToken>());

            //Asserts
            response.Should().NotBeNull();
            response.Should().BeOfType(typeof(ApartmentSaveOrUpdateViewModel));
        }
    }
}