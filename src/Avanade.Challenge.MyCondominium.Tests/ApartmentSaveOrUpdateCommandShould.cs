using Avanade.Challenge.MyCondominium.Domain.Entities;
using Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories;
using Moq;
using Xunit;
using FluentAssertions;
using System;
using System.Threading;

namespace Avanade.Challenge.MyCondominium.Tests
{
    public class ApartmentSaveOrUpdateCommandShould
    {
        protected readonly Mock<IApartmentRepository> ApartmentRepository;

        public ApartmentSaveOrUpdateCommandShould()
        {
            this.ApartmentRepository = new Mock<IApartmentRepository>();
        }

        [Fact]
        public void SaveOrUpdateShouldReturnAparment()
        {
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

            var result = ApartmentRepository
            .Setup(x => x.GetAsync(apartmentId, It.IsAny<CancellationToken>()))
            .Returns(taskApartment);
                        
            var apartment = ApartmentRepository.Object.GetAsync(entity.Id, It.IsAny<CancellationToken>()).Result;

            result.Should().NotBeNull();
            Assert.IsAssignableFrom<Mock<Apartment>>(apartment);            
        }
    }
}