using AutoMapper;
using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using BookingService.Application.UseCase.Address.Queries.GetAddress;
using BookingService.Application.UseCase.Address.Queries.GetAllAddress;
using BookingService.Application.UseCase.Company.Command.CreatedCompany;
using BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId;
using BookingService.Application.UseCase.Reservation.Queries.GetCompletedReservations;
using BookingService.Application.UseCase.Reservation.Queries.GetIncomingReservations;
using BookingService.Application.UseCase.Service.Commands.AddService;
using BookingService.Application.UseCase.Service.Queries.GetAllServices;
using BookingService.Application.UseCase.Service.Queries.GetCompanyServices;
using BookingService.Application.UseCase.Service.Queries.GetPossibleServiceHours;
using BookingService.Application.UseCase.Service.Queries.GetServiceDetalis;
using BookingService.Application.UseCase.Service.Queries.GetServicesLightModel;
using BookingService.Application.UseCase.User.Commands.CreateUser;
using BookingService.Application.UseCase.User.Queries.GetUser;
using BookingService.Domain.Entities;
using BookingService.Domain.ValueObject;

namespace BookingService.Application.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Address, CreatedAddressCommand>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<Address, AddressInListViewModel>().ReverseMap();
            CreateMap<Address, CreatedCompanyCommand>().ReverseMap();

            CreateMap<Service, ServiceInListViewModel>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company != null ? src.Company.Id : 0));
            CreateMap<Service, ServiceLightModel>()
                .ForMember(dest => dest.ComapnyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.Name : ""));
            CreateMap<CreatedServiceCommand, Service>();
            CreateMap<Service, CompanyServiceViewModel>();
            CreateMap<Service, ServiceDetalisViewModel>().ReverseMap();
            CreateMap<ServiceTime, PossibleServiceHourViewModel>();

            CreateMap<User, RegisteryCommand>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();

            CreateMap<CompanyByUserIdViewModel, Company>().ReverseMap();
            CreateMap<Calendar, CreatedCompanyCommand>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CalendaryName));

            CreateMap<IncomingReservationViewModel, Reservation>().ReverseMap()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Service != null ? src.Service.Company.Name : ""));
            CreateMap<CompletedReservationViewModel, Reservation>().ReverseMap()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Service != null ? src.Service.Company.Name : ""));
        }
    }
}
