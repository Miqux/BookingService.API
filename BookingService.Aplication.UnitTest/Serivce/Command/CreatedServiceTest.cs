﻿using AutoMapper;
using BookingService.Aplication.UnitTest.Company;
using BookingService.Application.Contracts.Persistance;
using BookingService.Application.Mapper;
using BookingService.Application.UseCase.Service.Commands.CreateService;
using Moq;
using Shouldly;
using Xunit;

namespace BookingService.Aplication.UnitTest.Serivce.Command
{
    public class CreatedServiceTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IServiceRepository> serviceRepository;
        private readonly Mock<ICompanyRepository> companyRepository;
        public CreatedServiceTest()
        {
            mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingConfiguration>();
            }).CreateMapper();
            serviceRepository = ServiceRepositoryMock.GetServiceRepository();
            companyRepository = CompanyRepositoryMock.GetCompanyRepository();
        }

        [Fact]
        public async Task Handle_ValidService_AddedToServiceRepo()
        {
            var handler = new CreateServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object);

            int serviceCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreateServiceCommand()
            {
                Name = "TestowaUsługa1",
                Cost = 86.4M,
                DurationInMinutes = 90,
                CompanyId = 1,
                Type = Domain.Entities.Enums.ServiceType.Combo
            }, CancellationToken.None);

            int serviceCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            response.ServiceId.ShouldNotBeNull();
            serviceCountAfterCommand.ShouldBe(serviceCountBeforeCommand + 1);
        }
        [Fact]
        public async Task Handle_WrongNameService_DontAddedToServiceRepo()
        {
            var handler = new CreateServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreateServiceCommand()
            {
                Name = "aa",
                Cost = 86.4M,
                DurationInMinutes = 90,
                CompanyId = 1,
                Type = Domain.Entities.Enums.ServiceType.Combo
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongNumberValueService_DontAddedToServiceRepo()
        {
            var handler = new CreateServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreateServiceCommand()
            {
                Name = "aasdda",
                Cost = -12,
                DurationInMinutes = 0,
                CompanyId = 1,
                Type = Domain.Entities.Enums.ServiceType.Haircut
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(2);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongValueService_DontAddedToServiceRepo()
        {
            var handler = new CreateServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreateServiceCommand()
            {
                Name = "s",
                Cost = -12,
                DurationInMinutes = 0,
                CompanyId = 1,
                Type = Domain.Entities.Enums.ServiceType.BeardTrimming
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(3);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
        [Fact]
        public async Task Handle_WrongCompanyId_DontAddedToServiceRepo()
        {
            var handler = new CreateServiceCommandHandler(mapper, serviceRepository.Object, companyRepository.Object);

            int userCountBeforeCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            var response = await handler.Handle(new CreateServiceCommand()
            {
                Name = "sasdda",
                Cost = 12,
                DurationInMinutes = 12,
                CompanyId = 13,
                Type = Domain.Entities.Enums.ServiceType.Combo
            }, CancellationToken.None);

            int userCountAfterCommand = serviceRepository.Object.GetAllAsync().Result.Count;

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            response.ServiceId.ShouldBeNull();
            userCountAfterCommand.ShouldBe(userCountBeforeCommand);
        }
    }
}
