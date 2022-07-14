using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Moq;
using Xunit;
using FluentAssertions;
using Avanade.Challenge.MyCondominium.Application.Commands.ApartmentInsert;
using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.API.ViewModels;

namespace Avanade.Challenge.MyCondominium.Tests
{
    public class ApartmentSaveOrUpdateCommandShould
    {
        private readonly Mock<IApartmentRepository> ApartmentRepository;
        private Mock<ILogger> _logger { get; set; }

        public ApartmentSaveOrUpdateCommandShould(ILogger logger
            , IApartmentRepository apartmentRepository)
        {
            this._logger = new Mock<ILogger>();
            this.ApartmentRepository = new Mock<IApartmentRepository>();
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

            Task<Apartment?> taskApartment = Task.FromResult(entity);
            var logger = new Mock<ILogger>();
            var request = new ApartmentSaveOrUpdateRequest()
            {
                Id = entity.Id,
                Name = entity?.Name,
                Block = entity?.Block,
                Floor = entity?.Floor
            };

            var apartmentVMResult = new ApartmentSaveOrUpdateViewModel()
            {
                Id = entity.Id,
                Name = entity?.Name,
                Block = entity?.Block,
                Floor = entity?.Floor,
                Created = entity.Created
            };

            //Act
            var result = ApartmentRepository
                        .Setup(x => x.GetAsync(apartmentId, It.IsAny<CancellationToken>()))
                        .Returns(taskApartment);

            var apartmentSaveOrUpdateCommand = new ApartmentSaveOrUpdateCommand(logger.Object,
                                            this.ApartmentRepository.Object);

            var response = apartmentSaveOrUpdateCommand.Handle(request, It.IsAny<CancellationToken>());


            var apartment = ApartmentRepository.Object.GetAsync(entity.Id, It.IsAny<CancellationToken>()).Result;

            result.Should().NotBeNull();
            Assert.IsAssignableFrom<Mock<Apartment>>(apartment);
        }
    }
}