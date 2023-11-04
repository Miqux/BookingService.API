using AutoMapper;
using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using BookingService.Domain.Entities;

namespace BookingService.Application.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            //CreateMap<Address, CreatedAddressCommand>();
            CreateMap<Address, CreatedAddressCommand>().ReverseMap();
        }
    }
}
