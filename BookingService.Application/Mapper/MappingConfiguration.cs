using AutoMapper;
using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using BookingService.Application.UseCase.Address.Queries.GetAddress;
using BookingService.Application.UseCase.Address.Queries.GetAllAddress;
using BookingService.Application.UseCase.User.Commands.CreateUser;
using BookingService.Domain.Entities;

namespace BookingService.Application.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Address, CreatedAddressCommand>().ReverseMap();
            CreateMap<User, RegisteryCommand>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<Address, AddressInListViewModel>().ReverseMap();
        }
    }
}
