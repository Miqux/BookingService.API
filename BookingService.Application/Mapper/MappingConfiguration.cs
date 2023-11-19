using AutoMapper;
using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using BookingService.Application.UseCase.Address.Queries.GetAddress;
using BookingService.Application.UseCase.Address.Queries.GetAllAddress;
using BookingService.Application.UseCase.Service.Commands;
using BookingService.Application.UseCase.Service.Queries.GetAllServices;
using BookingService.Application.UseCase.User.Commands.CreateUser;
using BookingService.Application.UseCase.User.Queries.GetUser;
using BookingService.Domain.Entities;

namespace BookingService.Application.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Address, CreatedAddressCommand>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<Address, AddressInListViewModel>().ReverseMap();

            CreateMap<Service, ServiceInListViewModel>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company != null ? src.Company.Id : 0))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.Id : 0));
            CreateMap<CreatedServiceCommand, Service>();

            CreateMap<User, RegisteryCommand>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
