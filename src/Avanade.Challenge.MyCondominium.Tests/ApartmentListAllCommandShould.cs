using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Avanade.Challenge.MyCondominium.API.ViewModels;
using Avanade.Challenge.MyCondominium.Application.Commands.ApartmentListAll;

namespace Avanade.Challenge.MyCondominium.Tests
{
    public class ApartmentListAllCommandShould
    {
        protected readonly Mock<IApartmentRepository> MockApartmentRepository;

        public ApartmentListAllCommandShould()
        {
            this.MockApartmentRepository = new Mock<IApartmentRepository>();
        }

        [Fact]
        public void ListAllAparmentThatShouldNotBeNull()
        {
            //Arrange                      
            int apartmentId = 104;
            var createdIn = new DateTime(2022, 07, 14);
            var apartment = new Apartment()
            {
                Id = apartmentId,
                Name = "104",
                Floor = "1",
                Block = "7",
                Created = createdIn,
                LastUpdated = createdIn
            };

            IList<Apartment>? aparmentList = new List<Apartment>() { apartment };
            var expectedRepositoryList = Task.FromResult(aparmentList);

            var mocklogger = new Mock<ILogger>();
            var request = new ApartmentListAllRequest();
            var taskApartment = new ApartmentListAllViewModel()
            {
                ApartmentDTOs = aparmentList.Select(item => new ApartmentListAllDto()
                {
                    Id = item.Id,
                    Name = item?.Name,
                    Block = item?.Block,
                    Floor = item?.Floor,
                    Created = item?.Created
                }).ToList()
            };
            var expectedResponse = Task.FromResult(taskApartment);

            //Act
            _= MockApartmentRepository
                           .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                           .Returns(expectedRepositoryList);
            
            var sut = new ApartmentListAllCommand(mocklogger.Object, this.MockApartmentRepository.Object);

            var response = sut.Handle(request, It.IsAny<CancellationToken>());

            //Asserts
            response.Result.Should().NotBeNull();            
            response.Result.Should().BeAssignableTo(typeof(ApartmentListAllViewModel));
            _ = response.Result.ApartmentDTOs.Should().BeEquivalentTo(expectedResponse.Result.ApartmentDTOs);
        }
    }
}