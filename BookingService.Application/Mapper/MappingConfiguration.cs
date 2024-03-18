using BookingService.Application.UseCase.Address.Commands.CreateAddress;
using BookingService.Application.UseCase.Address.Queries.GetAddress;
using BookingService.Application.UseCase.Address.Queries.GetAllAddress;
using BookingService.Application.UseCase.Company.Commands.CreateCompany;
using BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId;
using BookingService.Application.UseCase.Post.Commands.CreatePost;
using BookingService.Application.UseCase.Post.Queries.GetPosts;
using BookingService.Application.UseCase.Reservation.Queries.GetCompletedReservations;
using BookingService.Application.UseCase.Reservation.Queries.GetIncomingReservations;
using BookingService.Application.UseCase.Service.Commands.CreateService;
using BookingService.Application.UseCase.Service.Queries.GetAllServices;
using BookingService.Application.UseCase.Service.Queries.GetCompanyServices;
using BookingService.Application.UseCase.Service.Queries.GetPossibleServiceHours;
using BookingService.Application.UseCase.Service.Queries.GetServiceDetalis;
using BookingService.Application.UseCase.Service.Queries.GetServicesLightModel;
using BookingService.Application.UseCase.User.Commands.CreateUser;
using BookingService.Application.UseCase.User.Queries.GetUser;
using BookingService.Application.UseCase.User.Queries.GetUsersAdministration;
using BookingService.Domain.ValueObject;

namespace BookingService.Application.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<Address, AddressInListViewModel>().ReverseMap();
            CreateMap<Address, CreateCompanyCommand>().ReverseMap();

            CreateMap<Service, ServiceInListViewModel>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company != null ? src.Company.Id : 0));
            CreateMap<Service, ServiceLightViewModel>()
                .ForMember(dest => dest.ComapnyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.Name : ""));
            CreateMap<CreateServiceCommand, Service>();
            CreateMap<Service, CompanyServiceViewModel>();
            CreateMap<Service, ServiceDetalisViewModel>().ReverseMap();
            CreateMap<ServiceTime, PossibleServiceHourViewModel>();

            CreateMap<User, RegisteryCommand>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<User, UserAdministrationViewModel>();

            CreateMap<CompanyByUserIdViewModel, Company>().ReverseMap();
            CreateMap<Calendar, CreateCompanyCommand>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CalendaryName));

            CreateMap<IncomingReservationViewModel, Reservation>().ReverseMap()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Service != null ? src.Service.Company.Name : ""));
            CreateMap<CompletedReservationViewModel, Reservation>().ReverseMap()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Service != null ? src.Service.Company.Name : ""));

            CreateMap<CreatePostCommand, Post>();
            CreateMap<Post, PostViewModel>();
        }
    }
}
